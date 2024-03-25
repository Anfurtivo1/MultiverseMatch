using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static OpcionesNivelesManager;

public class CartasManager : MonoBehaviour
{
    public Carta cartaPrefab;
    public Transform cartaZonaSpawn;

    [HideInInspector]
    public List<Carta> cartaList;

    public bool scaledDown;
    public Vector2 posicionInicial;

    public Vector2 espacioCartas;
    public Vector2 espacioCartas15 = new Vector2(1.08f,1.22f);
    public Vector2 espacioCartas20 = new Vector2(1.08f,1.0f);

    public Vector3 cartasScaledDown = new Vector3 (0.9f, 0.9f, 0.01f);

    public int velocidadMovimientoCarta = 40;


    private List<Material> _materialList = new List<Material>();
    private List<string> _texturePathList = new List<string>();
    private Material _primerMaterial;
    private string _primeraRutaTextura;

    private Carta _primeraCartaRevelada;
    private Carta _segundaCartaRevelada;

    private int score;
    private int intentos;
    public float tiempo = 19;

    public bool empezarTiempo = false;
    public bool ganar = false;
    public bool girable = true;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _intentosText;

    
    public TextMeshProUGUI tiempoText;

    public GameObject menuGanar;
    public GameObject menuPerder;

    public GameObject bgOeste;
    public GameObject bgEspacio;
    public GameObject bgMedieval;

    public GameObject tapeteOeste;
    public GameObject tapeteEspacio;
    public GameObject tapeteMedieval;

    public AudioClip musicaNivelOeste;
    public AudioClip musicaNivelEspacio;
    public AudioClip musicaNivelMedieval;

    public AudioClip sfxGirarCarta;
    public AudioClip sfxAcertado;
    public AudioClip sfxErroneo;

    public AudioSource src;
    public AudioSource srcCarta;

    public GameObject panelIzq;
    public GameObject panelDer;


    // Start is called before the first frame update
    void Start()
    {
        
        CargarMateriales();

        if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == OpcionesNivelesManager.CantidadCartas.Cartas10)
        {
            SpawnearCarta(4, 5, posicionInicial, espacioCartas,false);
            MoverCarta(4, 5, posicionInicial, espacioCartas);
        }else if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == OpcionesNivelesManager.CantidadCartas.Cartas15)
        {
            SpawnearCarta(5, 6, posicionInicial, espacioCartas15, false);
            MoverCarta(5, 6, posicionInicial, espacioCartas15);
        }
        else if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == OpcionesNivelesManager.CantidadCartas.Cartas20)
        {
            SpawnearCarta(5, 8, posicionInicial, espacioCartas20,true);
            MoverCarta(5, 8, posicionInicial, espacioCartas20);
        }

        if (OpcionesNivelesManager.instanciaOpcionesNivel.GetEsitloJuego() == EstiloJuego.Oeste)
        {
            bgOeste.SetActive(true);
            bgEspacio.SetActive(false);
            bgMedieval.SetActive(false);

            src.clip = musicaNivelOeste;
            src.Play();

            tapeteOeste.SetActive(true);
            tapeteEspacio.SetActive(false);
            tapeteMedieval.SetActive(false);
        }
        else if (OpcionesNivelesManager.instanciaOpcionesNivel.GetEsitloJuego() == EstiloJuego.Espacio)
        {
            bgOeste.SetActive(false);
            bgEspacio.SetActive(true);
            bgMedieval.SetActive(false);

            src.clip = musicaNivelEspacio;
            src.Play();

            tapeteOeste.SetActive(false);
            tapeteEspacio.SetActive(true);
            tapeteMedieval.SetActive(false);
        }
        else if (OpcionesNivelesManager.instanciaOpcionesNivel.GetEsitloJuego() == EstiloJuego.Medieval)
        {
            bgOeste.SetActive(false);
            bgEspacio.SetActive(false);
            bgMedieval.SetActive(true);

            src.clip = musicaNivelMedieval;
            src.Play();

            tapeteOeste.SetActive(false);
            tapeteEspacio.SetActive(false);
            tapeteMedieval.SetActive(true);
        }


    }

    private void comprobarUI()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            panelDer.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            panelIzq.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            //botonesMenuprincipal.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            //txtTitulo.fontSize = 30;
        }

        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            panelDer.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
            panelIzq.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
            //botonesMenuprincipal.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            //txtTitulo.fontSize = 80;
        }
    }

    private void Update()
    {
        comprobarUI();


        if (empezarTiempo && tiempo >= 0 && ganar == false)
        {
            float nuevoTiempo = tiempo - Time.deltaTime;
            tiempo = nuevoTiempo;
            
            tiempoText.text = "Tiempo: " + nuevoTiempo.ToString("f0");
        }

        //Menu de perder
        if (tiempo <= 0)
        {
            //tiempo = 0;
            //Debug.Log("Has perdido");
            //menuPerder.SetActive(true);
            //girable = false;

            instanciaOpcionesNivel.scoreFinal = score;
            instanciaOpcionesNivel.intentosFinales = intentos;

            SceneManager.LoadScene("MenuPerder");

        }

        //Menu de ganar
        if(OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == CantidadCartas.Cartas10 && score == 10)
        {
            //Debug.Log("Has ganado");
            //ganar = true;
            //girable = false;
            //menuGanar.SetActive(true);
            instanciaOpcionesNivel.scoreFinal = score;
            instanciaOpcionesNivel.intentosFinales = intentos;
            instanciaOpcionesNivel.tiempoRestante = tiempo.ToString("f0");

            SceneManager.LoadScene("MenuGanar");

        }

        if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == CantidadCartas.Cartas15 && score == 15)
        {
            //Debug.Log("Has ganado");
            //ganar = true;
            //girable = false;
            //menuGanar.SetActive(true);

            instanciaOpcionesNivel.scoreFinal = score;
            instanciaOpcionesNivel.intentosFinales = intentos;
            instanciaOpcionesNivel.tiempoRestante = tiempo.ToString("f0");

            SceneManager.LoadScene("MenuGanar");
        }

        if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == CantidadCartas.Cartas20 && score == 20)
        {
            //Debug.Log("Has ganado");
            //ganar = true;
            //girable = false;
            //menuGanar.SetActive(true);

            instanciaOpcionesNivel.scoreFinal = score;
            instanciaOpcionesNivel.intentosFinales = intentos;
            instanciaOpcionesNivel.tiempoRestante = tiempo.ToString("f0");

            SceneManager.LoadScene("MenuGanar");
        }

    }

    public void CargarMateriales()
    {
        var rutaMaterial = OpcionesNivelesManager.instanciaOpcionesNivel.GetNombreDirectorioMaterial();
        var rutaTexturaMaterial = OpcionesNivelesManager.instanciaOpcionesNivel.GetTexturaCartaCategoriaDirectorio();
        var numeroCartas = (int)OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas();

        const string materialBase = "Carta ";
        var nombrePrimerMaterial = "Trasero";

        for (int i = 1; i <= numeroCartas; i++)
        {
            var directorioActual = rutaMaterial + materialBase + i;
            Material mat = Resources.Load(directorioActual, typeof(Material)) as Material;
            _materialList.Add(mat);



            var directorioActualTextura = rutaTexturaMaterial + materialBase + i;
            _texturePathList.Add(directorioActualTextura);
        }
        //
        _primeraRutaTextura = rutaTexturaMaterial + nombrePrimerMaterial;
        _primerMaterial = Resources.Load(rutaMaterial + nombrePrimerMaterial, typeof(Material)) as Material;





    }

    private void SpawnearCarta(int filas, int columnas, Vector2 posicion, Vector2 espacio, bool scaledDown)
    {
        for (int col = 0; col < columnas; col++)
        {
            for (int fila = 0; fila < filas; fila++)
            {
                var cartaTemporal = (Carta)Instantiate(cartaPrefab, cartaZonaSpawn.position, cartaPrefab.transform.rotation);
                cartaTemporal.cartaManager = this;

                if (scaledDown)
                {
                    cartaTemporal.transform.localScale = cartasScaledDown;
                }

                cartaTemporal.name = cartaTemporal.name + "columna " + col + " fila " + fila;
                cartaList.Add(cartaTemporal);

            }
        }

        AplicarTexturas();

    }

    private void MoverCarta(int filas, int columnas, Vector2 posicion, Vector2 espacio)
    {
        var index = 0;

        for (int col = 0; col < columnas; col++)
        {
            for (int fila = 0; fila < filas; fila++)
            {
                var moverPosicion = new Vector3((posicion.x + (espacio.x * fila)),(posicion.y - (espacio.y * col)),87.0f);
                StartCoroutine(MoverPosicionCarta(moverPosicion, cartaList[index]));
                index++;

            }
            
        }

    }

    public void AplicarTexturas()
    {
        var posicionRandomMaterial = Random.Range(0,_materialList.Count);
        var vecesAplicado = new int[_materialList.Count];

        for (int i = 0; i < _materialList.Count; i++)
        {
            vecesAplicado[i] = 0;
        }

        foreach (var carta in cartaList)
        {
            var randomAnterior = posicionRandomMaterial;
            //
            var counter = 0;
            var materialForzado = false;

            while (vecesAplicado[posicionRandomMaterial] >= 2 || ((randomAnterior == posicionRandomMaterial) && !materialForzado))
            {
                posicionRandomMaterial = Random.Range(0,_materialList.Count);
                //
                counter++;
                if (counter > 100)
                {
                    for (int i = 0; i < _materialList.Count; i++)
                    {
                        if (vecesAplicado[i] <2)
                        {
                            posicionRandomMaterial = i;
                            materialForzado = true;
                        }
                    }
                    //
                    if (materialForzado == false)
                    {
                        return;
                    }

                }
            }

            carta.cartaId = posicionRandomMaterial;
            carta.CrearMaterialTrasero(_primerMaterial, _primeraRutaTextura);
            carta.AplicarMaterialTrasero();

            carta.CrearMaterialFrontal(_materialList[posicionRandomMaterial], _texturePathList[posicionRandomMaterial]);
            //carta.AplicarMaterialFrontal();

            vecesAplicado[posicionRandomMaterial] += 1;
            materialForzado = false;

        }

    }

    IEnumerator MoverPosicionCarta(Vector3 posicion, Carta carta)
    {
        

        while (carta.transform.position != posicion)
        {
            carta.transform.position = Vector3.MoveTowards(carta.transform.position, posicion, velocidadMovimientoCarta * Time.deltaTime);
            yield return 0;
        }

        
    }

    public void GirarCarta(Carta carta)
    {
        srcCarta.clip = sfxGirarCarta;
        srcCarta.Play();
        if (_primeraCartaRevelada == null)
        {
            _primeraCartaRevelada = carta;
        }
        else
        {
            _segundaCartaRevelada = carta;
            StartCoroutine(ComprobarPareja());
        }
    }

    private IEnumerator ComprobarPareja()
    {
        string carta1Id =""+ _primeraCartaRevelada.cartaId;
        string carta2Id = ""+ _segundaCartaRevelada.cartaId;

        girable = false;

        //Debug.Log("La primera carta tiene un id de: "+ carta1Id + " y la segunda carta tiene un id de: "+ carta2Id);
        if (carta1Id == carta2Id)
        {
            yield return new WaitForSeconds(0.3f);

            srcCarta.clip = sfxAcertado;
            srcCarta.Play();

            tiempo = tiempo + 20;

            score++;
            _scoreText.text = "Score: " + score;
            //Debug.Log("Has anotado un punto mas");
            girable = true;
        }
        else
        {

            yield return new WaitForSeconds(2);

            srcCarta.clip = sfxErroneo;
            srcCarta.Play();

            //Debug.Log("No son iguales");
            _primeraCartaRevelada.animator.SetTrigger("Voltear");
            _segundaCartaRevelada.animator.SetTrigger("Voltear");

            _primeraCartaRevelada.pulsada = false;
            _segundaCartaRevelada.pulsada = false;
            girable = true;

        }

        intentos++;
        _intentosText.text = "Intentos: "+intentos;

        _primeraCartaRevelada = null;
        _segundaCartaRevelada = null;
        
    }



}
