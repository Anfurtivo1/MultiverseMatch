using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesNivelesManager : MonoBehaviour
{
    private int _opciones;
    //
    private const int numeroOpciones = 2;




    private Juego _juego;

    //usamos un singleton para luego aplicarles los valores del nivel
    public static OpcionesNivelesManager instanciaOpcionesNivel = new OpcionesNivelesManager();

    public enum CantidadCartas
    {
        sinCartas = 0,
        Cartas10 = 10,
        Cartas15 = 15,
        Cartas20 = 20,

    }

    public enum EstiloJuego
    {
        SinTema,
        Oeste,
        Espacio,
        Medieval
    }

    //Pequeña clase encapsulando todo lo que llevaría las opciones del juego
    public struct Juego
    {
        public CantidadCartas cantidadCartas;
        public EstiloJuego estiloJuego;
    }



    private void Awake()
    {
        if (instanciaOpcionesNivel == null)
        {
            DontDestroyOnLoad(this);
            instanciaOpcionesNivel = this;
        }
        else
        {
            Destroy(this);
        }
    }


    
    void Start()
    {
        _juego = new Juego();
        ResetOpciones();
    }

    public void ElegirCantidadCartas(CantidadCartas cantidadCartas)
    {
        if (_juego.cantidadCartas == CantidadCartas.sinCartas)
        {
            _opciones++;
        }
        _juego.cantidadCartas = cantidadCartas;
    }

    public void ElegirEstiloNivel(EstiloJuego estiloJuego)
    {
        if (_juego.estiloJuego == EstiloJuego.SinTema)
        {
            _opciones++;
        }
        _juego.estiloJuego = estiloJuego;
    }

    public EstiloJuego GetEsitloJuego()
    {
        return _juego.estiloJuego;
    }

    public CantidadCartas GetCantidadCartas()
    {
        return _juego.cantidadCartas;
    }

    public void ResetOpciones()
    {
        _opciones = 0;
        _juego.cantidadCartas = CantidadCartas.sinCartas;
        _juego.estiloJuego = EstiloJuego.SinTema;

    }

    public bool OpcionesPreparadas()
    {
        return _opciones == numeroOpciones;
    }

}
