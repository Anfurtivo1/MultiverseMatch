using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    private Material _material1;
    private Material _material2;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        animator.SetTrigger("Rotar");
    }

    public void CrearMaterial1(Material mat, string texturepath)
    {
        _material1 = mat;
        _material1.mainTexture = Resources.Load(texturepath,typeof(Texture2D)) as Texture2D;
    }

    public void CrearMaterial2(Material mat, string texturepath)
    {
        _material2 = mat;
        _material2.mainTexture = Resources.Load(texturepath, typeof(Texture2D)) as Texture2D;
    }

    public void AplicarMaterial1()
    {
        gameObject.GetComponent<Renderer>().material = _material1;
    }

    public void AplicarMaterial2()
    {
        gameObject.GetComponent<Renderer>().material = _material2;
    }

}
