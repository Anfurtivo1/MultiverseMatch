using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGanarPerder : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textoIntentos;
    public TextMeshProUGUI textoTiempoRestante;

    public GameObject bgOeste;
    public GameObject bgEspacio;
    public GameObject bgMedieval;

    public GameObject medOro;
    public GameObject medPlata;
    public GameObject medBronce;

    // Start is called before the first frame update
    void Start()
    {

        switch (OpcionesNivelesManager.instanciaOpcionesNivel.GetEsitloJuego())
        {
            case OpcionesNivelesManager.EstiloJuego.Oeste:
                bgOeste.SetActive(true);
                textoScore.text = "Score: " + OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal;
                textoIntentos.text = "Intentos: " + OpcionesNivelesManager.instanciaOpcionesNivel.intentosFinales;

                if (SceneManager.GetActiveScene().name == "MenuGanar")
                {
                    if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 20)
                    {
                        medOro.SetActive(true);
                    }
                    else if(OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 15)
                    {
                        medPlata.SetActive(true);
                    }
                    else if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 10)
                    {
                        medBronce.SetActive(true);
                    }

                    textoTiempoRestante.text = "Tiempo restante: "+ OpcionesNivelesManager.instanciaOpcionesNivel.tiempoRestante;
                }

                break;
            case OpcionesNivelesManager.EstiloJuego.Espacio:
                bgEspacio.SetActive(true);
                textoScore.text = "Score: " + OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal;
                textoIntentos.text = "Intentos: " + OpcionesNivelesManager.instanciaOpcionesNivel.intentosFinales;

                if (SceneManager.GetActiveScene().name == "MenuGanar")
                {

                    if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 20)
                    {
                        medOro.SetActive(true);
                    }
                    else if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 15)
                    {
                        medPlata.SetActive(true);
                    }
                    else if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 10)
                    {
                        medBronce.SetActive(true);
                    }

                    textoTiempoRestante.text = "Tiempo restante: " + OpcionesNivelesManager.instanciaOpcionesNivel.tiempoRestante;
                }

                break;
            case OpcionesNivelesManager.EstiloJuego.Medieval:
                bgMedieval.SetActive(true);
                textoScore.text = "Score: " + OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal;
                textoIntentos.text = "Intentos: " + OpcionesNivelesManager.instanciaOpcionesNivel.intentosFinales;

                if (SceneManager.GetActiveScene().name == "MenuGanar")
                {

                    if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 20)
                    {
                        medOro.SetActive(true);
                    }
                    else if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 15)
                    {
                        medPlata.SetActive(true);
                    }
                    else if (OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal == 10)
                    {
                        medBronce.SetActive(true);
                    }

                    textoTiempoRestante.text = "Tiempo restante: " + OpcionesNivelesManager.instanciaOpcionesNivel.tiempoRestante;
                }

                break;
            default:
                break;
        }

    }
}
