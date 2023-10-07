using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class panelsshifting : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelGenral;
    public GameObject opcionesPanel;
    public GameObject creditosPanel;
    public AudioSource fxsound;
    public AudioClip sonido_click;

    //control de paneles
    public void OpenPanels(GameObject panel)
    {
        creditosPanel.SetActive(false);
        opcionesPanel.SetActive(false);
        panelGenral.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void PlaySoundButton()
    {
        fxsound.PlayOneShot(sonido_click);
    }
}
