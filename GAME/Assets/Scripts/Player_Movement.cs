using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float Acceleration;
    public CircleCollider2D ColliderCir2D;
    public CapsuleCollider2D ColliderCap2D;
    public float Contador_Esmeraldas = 0f;
    private Rigidbody2D Rb2D;
    private Animator Animator;
    private float Horizontal;
    public float JumpForce = 500f;
    private float MaxSpeed = 7f;
    private bool Grounded;
    private bool Salto;
    public bool Hit;
    public bool canmove = true;
    public bool Transformed = false;
    public bool Attack = false;
    [SerializeField] private Vector2 Velrebote;
    [SerializeField] private float tiempoControl;
    public AudioClip sonido;
    [SerializeField] private Cant_vidas aux1;
    [SerializeField] private Cant_rings comp;
    [SerializeField] private GameObject pass;
    [SerializeField] private GameObject other;
    [SerializeField] private GameObject trans;
    public bool active=true;
    public AudioClip trampolin;
    public AudioClip golpeado;


    public Animator anim;
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Vector3 position = gameObject.transform.position;
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    void Update()
    {
        if (canmove)
        {
            Horizontal = Input.GetAxis("Horizontal");
            JumpForce = 500f;
        }
        else
        {
            JumpForce = 0f;
            Horizontal = 0f;
        }

        if (Horizontal != 0)
        {
            RunningSpeed();
        }
        else if (Horizontal == 0.0f)
        {
            Speed = 1.0f;
        }

        if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(Rb2D.transform.position, Rb2D.transform.up * -0.4f, UnityEngine.Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.4f))
        {
            Grounded = true;
            Animator.SetTrigger("Grounded");
        }
        else
        {
            Grounded = false;
            Animator.ResetTrigger("Grounded");
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && Grounded == true)
        {
            Jump();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
            Salto = true;
        }

        if (Grounded)
        {
            Animator.SetBool("Salto", false);
            ColliderCir2D.enabled = false;
            ColliderCap2D.enabled = true;
        }
        else
        {
            ColliderCir2D.enabled = true;
            ColliderCap2D.enabled = false;
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && Grounded)
        {
            Animator.SetTrigger("Bolita");
            Attack = true;
            StartCoroutine(BolitaToRun());
        }
        if(Contador_Esmeraldas==7f && active)
        {
            Time.timeScale = 0f;
            trans.SetActive(true);
            other.SetActive(false);
        }
        

        if (Contador_Esmeraldas == 7f && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Animator.SetTrigger("Trans Anim");
            canmove = false;
            StartCoroutine(Transformation());
        }
        else
        {
            Animator.ResetTrigger("Trans Anim");
            Animator.SetBool("TtN", false);
        }

        if(Salto && Grounded == false)
        {
            Animator.SetBool("Salto", true);
        }

    }

    private void Jump()
    {
        Rb2D.AddForce(Vector2.up * JumpForce);
        StartCoroutine(SaltoAttack());
    }

    private void RunningSpeed()
    {
        Animator.SetFloat("Speed", Speed);
        Speed += Acceleration * Time.deltaTime;
        if (Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Esmeralda"))
        {
            Contador_Esmeraldas++;
            Debug.Log("Recogiste " + Contador_Esmeraldas);
        }
        
        if (other.CompareTag("Trampolin"))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(trampolin);
            StartCoroutine(SaltoTrampolin());
            Animator.SetBool("Trampolin", true);
            Rb2D.velocity = new Vector2(0f, 7f);
            Debug.Log("Saltaste en trampolin");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Vacio"))
        {
            aux1.quitarvidas();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trampolin"))
        {
            Animator.SetBool("Trampolin", false);
        }
    }

    private IEnumerator SaltoTrampolin()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(0.1f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private IEnumerator SaltoAttack()
    {
        Attack = true;
        yield return new WaitForSeconds(1.5f);
        Attack = false;
    }

    private IEnumerator BolitaToRun()
    {
        yield return new WaitForSeconds(2);
        Attack = false;
        Animator.ResetTrigger("Bolita");
        Animator.SetBool("BtR", true);
        yield return new WaitForSeconds(1);
        Animator.SetBool("BtR", false);
    }
    private IEnumerator Transformation()
    { 
        yield return new WaitForSeconds(1f);
        canmove = true;
        Animator.SetBool("Trans", true);
        Transformed = true;
        Debug.Log(5f * aux1.lifes);
        yield return new WaitForSeconds(3f * aux1.lifes);
        Animator.SetBool("Trans", false);
        Transformed = false;
        canmove = false;
        yield return new WaitForSeconds(1.1f);
        Animator.SetBool("TtN", true);
        canmove = true;
        Contador_Esmeraldas = 0f;
    }

    private IEnumerator HitSeconds()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(golpeado);
        Animator.SetBool("Hit", true);
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(1f);
        Animator.SetBool("Hit", false);
        Animator.SetBool("AfterHit", true);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        yield return new WaitForSeconds(0.5f);
        Animator.SetBool("AfterHit", false);
    }

    public void tomarDaño(Vector2 pos)
    {
        StartCoroutine(percontrol());
    }
    private IEnumerator percontrol()
    {
        canmove=false;
        yield return new WaitForSeconds(tiempoControl);
        canmove=true;
    }

    private void FixedUpdate()
    {
        Rb2D.velocity = new Vector2(Horizontal * Speed, Rb2D.velocity.y);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("bala"))
        {
            if (comp.cant > 0 )
            {
               
    
                comp.zeroring();
            }
            else
            {
                if (comp.cant == 0 && Transformed == false && Attack == false)
                {
                   
                    aux1.quitarvidas();
                }
            }
        }
        if (collision.transform.CompareTag("Enemigo") && Transformed == false && Attack == false)
        {
            Rb2D.velocity = new Vector2(1f, 5f);
            StartCoroutine(HitSeconds());
        }

        if (collision.transform.CompareTag("Bandera"))
        {
            Time.timeScale = 0f;
            pass.SetActive(true);
            other.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            pass.SetActive(false);
            other.SetActive(true);
        }
    }
}
