using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesOpcionesNivelManager : MonoBehaviour
{

    [SerializeField] public TipoBoton tipoBoton = TipoBoton.Ninguno;
    [HideInInspector] public OpcionesNivelesManager.CantidadCartas cantidadCartas = OpcionesNivelesManager.CantidadCartas.sinCartas;
    [HideInInspector] public OpcionesNivelesManager.EstiloJuego estiloJuego = OpcionesNivelesManager.EstiloJuego.SinTema;

    public enum TipoBoton
    {
        Ninguno,
        BotonCantidadCartas,
        BotonEstilo
    }


    public void ElegirOpcion(string NombreNivel)
    {
        var boton = gameObject.GetComponent<BotonesOpcionesNivelManager>();

        switch (boton.tipoBoton)
        {
            case BotonesOpcionesNivelManager.TipoBoton.BotonCantidadCartas:
                OpcionesNivelesManager.instanciaOpcionesNivel.ElegirCantidadCartas(boton.cantidadCartas);
                break;
            case BotonesOpcionesNivelManager.TipoBoton.BotonEstilo:
                OpcionesNivelesManager.instanciaOpcionesNivel.ElegirEstiloNivel(boton.estiloJuego);
                break;
            default:
                break;
        }

        if (OpcionesNivelesManager.instanciaOpcionesNivel.OpcionesPreparadas())
        {
            SceneManager.LoadScene(NombreNivel);
        }


    }

}
