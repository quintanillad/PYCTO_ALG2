using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static GameManager Instance { get; private set; }
    
	public HUD hud;

    public int PuntosTotales {get; private set;}

	private int vidas = 5;
    
	    private void Awake()
    {
		
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }
	public void PerderVida() {
		vidas -= 1;
		hud.DesactivarVida(vidas);
        if(vidas == 0)
		{
			// Reiniciamos el nivel.
			SceneManager.LoadScene(0);
		}
	}

	public bool RecuperarVida() {
		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
		
	}   
   }
