using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{

[SerializeField] private float tiempoMax;
[SerializeField] private Slider slider;
private float TiempoActual;
private bool TiempoActivado = false;

private void Start(){
   ActivarTemp();
}
private void Update(){
    if (TiempoActivado){
        CambiarContador();
    }
}
private void CambiarContador(){
   TiempoActual -= Time.deltaTime;
    if(TiempoActual >= 0){
        slider.value= TiempoActual;
    }
    if (TiempoActual <=0){
        SceneManager.LoadScene(0);
        CambiarTemp(false);
    }
}
private void CambiarTemp(bool estado){
    TiempoActivado = estado;
}
public void ActivarTemp(){
    TiempoActual = tiempoMax;
    slider.maxValue=tiempoMax;
    CambiarTemp(true);
}
public void DesactivarTemp(){
    CambiarTemp(false);
    }
}
