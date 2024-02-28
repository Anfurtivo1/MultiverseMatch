using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void BtnStart(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BtnRanking(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BtnOpciones(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BtnCreditos(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BtnSalir()
    {
        Application.Quit();
    }

    public void BtnVolverMenuPrincipal(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
