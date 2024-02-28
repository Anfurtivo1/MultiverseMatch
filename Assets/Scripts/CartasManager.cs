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

    private List<Material> _materialList;
    private List<string> _texturePathList;
    private Material _primerMaterial;
    private string _primerTextureList;

    // Start is called before the first frame update
    void Start()
    {
        CargarMateriales();
        SpawnearCarta(4,6,posicionInicial,espacioCartas);
        MoverCarta(4, 6, posicionInicial, espacioCartas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarMateriales()
    {

    }

    private void SpawnearCarta(int filas, int columnas, Vector2 posicion, Vector2 espacio)
    {
        for (int col = 0; col < columnas; col++)
        {
            for (int fila = 0; fila < filas; fila++)
            {
                var cartaTemporal = (Carta)Instantiate(cartaPrefab, cartaZonaSpawn.position, cartaZonaSpawn.transform.rotation);

                cartaTemporal.name = cartaTemporal.name + "columna " + col + " fila " + fila;
                cartaList.Add(cartaTemporal);

            }
        }
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
