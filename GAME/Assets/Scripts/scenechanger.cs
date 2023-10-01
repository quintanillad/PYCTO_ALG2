using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class scenechanger : MonoBehaviour
{
    //control de escenas y funcionalidad de botones

    [SerializeField] private AnimationClip cambio;
    private Animator an;

    private void Start()
    {
        an = GetComponent<Animator>();
    }
    public void Play(string sceneName)
    {
        an.SetTrigger("Cambio");
        new WaitForSeconds(cambio.length);
        SceneManager.LoadScene(sceneName);
    }
    public void Salir()
    {
        Application.Quit();
    }

    //control de paneles

    [Header("Opciones")]
    public Slider volumenFX;
    public Slider volumenMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsound;
    public AudioClip clicksound;
    private float lastvolumen;
    [Header("Paneles")]
    public GameObject panelGenral;
    public GameObject opcionesPanel;
    public GameObject creditosPanel;

    public void OpenPanels(GameObject panel)
    {
        creditosPanel.SetActive(false);
        opcionesPanel.SetActive(false);
        panelGenral.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    //control del sonido

    public void Volumenchanger(float volumen)
    {
        mixer.SetFloat("Volumen", volumen);
    }
    public void VolumenFXchanger(float volumen)
    {
        mixer.SetFloat("VolumenFX", volumen);
    }

    private void Awake()
    {
        volumenFX.onValueChanged.AddListener(VolumenFXchanger);
        volumenMaster.onValueChanged.AddListener(Volumenchanger);
    }

    public void PlaySoundButton()
    {
        fxsound.PlayOneShot(clicksound);
    }

    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("Volumen", out lastvolumen);
            mixer.SetFloat("Volumen", -80);
        }
        else
            mixer.SetFloat("Volumen", lastvolumen);
    }

}
