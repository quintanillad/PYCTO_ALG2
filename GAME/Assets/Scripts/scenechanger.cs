using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    [SerializeField] private AnimationClip cambio;
    private Animator an;

    private void Start()
    {
        an = GetComponent<Animator>();
    }
    public void Play()
    {
        an.SetTrigger("Cambio");
        new WaitForSeconds(cambio.length);
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
