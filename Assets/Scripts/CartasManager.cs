using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartasManager : MonoBehaviour
{
    public Carta cartaPrefab;
    public Transform cartaZonaSpawn;

    [HideInInspector]
    public List<Carta> cartaList;

    public Vector2 posicionInicial;
    public Vector2 espacioCartas;


    private List<Material> _materialList = new List<Material>();
    private List<string> _texturePathList = new List<string>();
    private Material _primerMaterial;
    private string _primeraRutaTextura;

    // Start is called before the first frame update
    void Start()
    {
        CargarMateriales();

        if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == OpcionesNivelesManager.CantidadCartas.Cartas10)
        {
            SpawnearCarta(4, 5, posicionInicial, espacioCartas);
            MoverCarta(4, 5, posicionInicial, espacioCartas);
        }else if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == OpcionesNivelesManager.CantidadCartas.Cartas15)
        {
            SpawnearCarta(5, 6, posicionInicial, espacioCartas);
            MoverCarta(5, 6, posicionInicial, espacioCartas);
        }
        else if (OpcionesNivelesManager.instanciaOpcionesNivel.GetCantidadCartas() == OpcionesNivelesManager.CantidadCartas.Cartas20)
        {
            SpawnearCarta(5, 8, posicionInicial, espacioCartas);
            MoverCarta(5, 8, posicionInicial, espacioCartas);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void SpawnearCarta(int filas, int columnas, Vector2 posicion, Vector2 espacio)
    {
        for (int col = 0; col < columnas; col++)
        {
            for (int fila = 0; fila < filas; fila++)
            {
                var cartaTemporal = (Carta)Instantiate(cartaPrefab, cartaZonaSpawn.position, cartaPrefab.transform.rotation);

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
                var moverPosicion = new Vector3((posicion.x + (espacio.x * fila)),(posicion.y - (espacio.y * col)),0.0f);
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

            carta.CrearMaterial1(_primerMaterial, _primeraRutaTextura);
            carta.AplicarMaterial1();

            carta.CrearMaterial2(_materialList[posicionRandomMaterial], _texturePathList[posicionRandomMaterial]);
            carta.AplicarMaterial2();

            vecesAplicado[posicionRandomMaterial] += 1;
            materialForzado = false;

        }

    }

    IEnumerator MoverPosicionCarta(Vector3 posicion, Carta carta)
    {
        var velocidadMovimiento = 80;

        while (carta.transform.position != posicion)
        {
            carta.transform.position = Vector3.MoveTowards(carta.transform.position, posicion, velocidadMovimiento * Time.deltaTime);
            yield return 0;
        }

        
    }

}
