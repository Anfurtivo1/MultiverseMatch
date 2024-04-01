using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public AudioSource src;

    public AudioClip sonidoBoton;

    public TextMeshProUGUI txtTitulo;
    public GridLayoutGroup botonesMenuprincipal;
    public GameObject menuOpciones;

    public Slider sliderMaster;
    public Slider sliderMusica;
    public Slider sliderSFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Master") || PlayerPrefs.HasKey("Musica") || PlayerPrefs.HasKey("SFX"))
        {
            sliderMaster.value = PlayerPrefs.GetFloat("Master");
            sliderMusica.value = PlayerPrefs.GetFloat("Musica");
            sliderSFX.value = PlayerPrefs.GetFloat("SFX");
        }
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Running on Android platform.");
            if (txtTitulo != null && botonesMenuprincipal != null)
            {
                if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
                {
                    botonesMenuprincipal.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                    txtTitulo.fontSize = 30;
                }

                if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
                {
                    botonesMenuprincipal.constraint = GridLayoutGroup.Constraint.FixedRowCount;
                    txtTitulo.fontSize = 80;
                }
            }
        }
        

    }
    public void BtnStart(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnRanking(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnOpciones()
    {
        src.clip = sonidoBoton;
        src.Play();
        menuOpciones.SetActive(true);
    }

    public void BtnSalirOpciones()
    {
        src.clip = sonidoBoton;
        src.Play();
        menuOpciones.SetActive(false);
        PlayerPrefs.SetFloat("Master",sliderMaster.value);
        PlayerPrefs.SetFloat("Musica", sliderMusica.value);
        PlayerPrefs.SetFloat("SFX", sliderSFX.value);
        PlayerPrefs.Save();
    }

    public void BtnCreditos(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();
        StartCoroutine(loadScene(scene));
    }

    public void BtnSalir()
    {
        Application.Quit();
    }

    public void BtnVolverMenuPrincipal(string scene)
    {
        src.clip = sonidoBoton;
        src.Play();

        if (OpcionesNivelesManager.instanciaOpcionesNivel != null)
        {
            OpcionesNivelesManager.instanciaOpcionesNivel.ResetOpciones();

        }
        
        StartCoroutine(loadScene(scene));
    }

    private IEnumerator loadScene(string scene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }

}
