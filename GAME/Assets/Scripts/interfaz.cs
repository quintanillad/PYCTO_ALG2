using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interfaz : MonoBehaviour
{
    public GameObject panel_pausa;
    //boton pausa
    public void pausa()
    {
        Time.timeScale = 0f;
    }

    public void menu_pausa(GameObject panel)
    {
        panel_pausa.SetActive(false);

        panel.SetActive(true);
    }
}
