using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
public float runspeed=2;
Rigidbody2D rb2D;

    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (Input.GetKey("d")||Input.GetKey("right")){
            rb2D.velocity= new Vector2(runspeed,rb2D.velocity.y);
        }
        else if(Input.GetKey("a")||Input.GetKey("left")){
            rb2D.velocity= new Vector2(-runspeed,rb2D.velocity.y);
        }else{
        rb2D.velocity= new Vector2(0,rb2D.velocity.y);
        }
        if (Input.GetKey("up")||Input.GetKey("w")){
        rb2D.velocity= new Vector2 (rb2D.velocity.x,runspeed);
        }
        else if (Input.GetKey("down")||Input.GetKey("s")){
        rb2D.velocity= new Vector2 (rb2D.velocity.x,-runspeed);
        }
        else{
            rb2D.velocity= new Vector2 (rb2D.velocity.x,0);
        }
    }    
    public void CambiarVelocidad(){
       if(Time.deltaTime % 3 == 0){
        runspeed = runspeed + 1;
        }
    }
}