using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    private Material _materialTrasero;
    private Material _materialFrontal;
    public Animator animator;
    public bool pulsada;
    public int cartaId;
    public CartasManager cartaManager;

    // Start is called before the first frame update
    void Start()
    {
        pulsada = false;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (pulsada == false)
        {
            animator.SetTrigger("Rotar");
            pulsada = true;
            //
            cartaManager.GirarCarta(this);
        }
    }

    public void CrearMaterialTrasero(Material mat, string texturepath)
    {
        _materialTrasero = mat;
        _materialTrasero.mainTexture = Resources.Load(texturepath,typeof(Texture2D)) as Texture2D;
    }

    public void CrearMaterialFrontal(Material mat, string texturepath)
    {
        _materialFrontal = mat;
        _materialFrontal.mainTexture = Resources.Load(texturepath, typeof(Texture2D)) as Texture2D;
    }

    public void AplicarMaterialTrasero()
    {
        gameObject.GetComponent<Renderer>().material = _materialTrasero;
    }

    public void AplicarMaterialFrontal()
    {
        gameObject.GetComponent<Renderer>().material = _materialFrontal;
    }

}
