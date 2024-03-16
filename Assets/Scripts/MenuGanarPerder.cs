using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuGanarPerder : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textoIntentos;
    // Start is called before the first frame update
    void Start()
    {
        textoScore.text = "Score: " + OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal;
        textoIntentos.text = "Intentos: " + OpcionesNivelesManager.instanciaOpcionesNivel.intentosFinales;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
