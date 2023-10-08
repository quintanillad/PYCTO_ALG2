using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interfaz : MonoBehaviour
{
    [SerializeField] private AnimationClip cambio;
    private Animator an;
    [SerializeField] private GameObject panel_pausa;
    private bool botonpausa = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (botonpausa)
            {
                reanudar();
            }
            else
            {
                pausa();
            }
        }
        
    }
    public void pausa()
    {
        botonpausa = true;
        Time.timeScale = 0f;
    }

    public void reanudar()
    {
        botonpausa = false;
        Time.timeScale = 1f;
    }
    private void Start()
    {
        an = GetComponent<Animator>();
    }

    public void salir()
    {
        Debug.Log("A cambiado a la escena 0");
        SceneManager.LoadScene(0);
    }

  
}
