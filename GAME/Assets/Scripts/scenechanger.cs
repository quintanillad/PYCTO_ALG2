using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("A salido del juego");
        Application.Quit();
    }

}
