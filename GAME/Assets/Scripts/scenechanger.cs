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
}
