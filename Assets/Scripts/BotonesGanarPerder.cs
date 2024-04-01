using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesGanarPerder : MonoBehaviour
{
    public void VolverMenuPrincipal()
    {
        OpcionesNivelesManager.instanciaOpcionesNivel.ResetOpciones();
        SceneManager.LoadScene("MenuPrincipal");
    }

}
