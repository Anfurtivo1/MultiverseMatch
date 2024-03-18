using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioSource src;

    public AudioClip sonidoBoton;

    public void BtnStart(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnRanking(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnOpciones(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnCreditos(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnSalir()
    {
        Application.Quit();
    }

    public void BtnVolverMenuPrincipal(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();

        OpcionesNivelesManager.instanciaOpcionesNivel.ResetOpciones();
        StartCoroutine(loadScene(scene));
    }

    private IEnumerator loadScene(string scene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }

}
