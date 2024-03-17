using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesNivelesManager : MonoBehaviour
{
    private int _opciones;
    //
    private const int numeroOpciones = 2;


    private Dictionary<EstiloJuego, string> _estiloCarta;


    private Juego _juego;

    //usamos un singleton para luego aplicarles los valores del nivel
    public static OpcionesNivelesManager instanciaOpcionesNivel;

    public int scoreFinal;
    public int intentosFinales;
    public string tiempoRestante;

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
        _estiloCarta = new Dictionary<EstiloJuego, string>();
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
        SetCategoriaCartaDirectorio(); 
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

    public string GetNombreDirectorioMaterial()
    {
        return "Materiales/";
    }

    public string GetTexturaCartaCategoriaDirectorio()
    {
        
        if (_estiloCarta.ContainsKey(_juego.estiloJuego))
        {
            return "Cartas/" + _estiloCarta[_juego.estiloJuego]+"/";
        }
        else
        {
            Debug.Log("El directorio:"+ "Resources/Cartas/" + _estiloCarta[_juego.estiloJuego] + "no existe");
            return "";
        }
    }
    
    private void SetCategoriaCartaDirectorio()
    {
        _estiloCarta.Add(EstiloJuego.Oeste, "Oeste");
        _estiloCarta.Add(EstiloJuego.Espacio, "Espacio");
        _estiloCarta.Add(EstiloJuego.Medieval, "Medieval");
    }

}
