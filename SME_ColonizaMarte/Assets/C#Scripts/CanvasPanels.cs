using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasPanels : MonoBehaviour
{
    [SerializeField] private GameObject canvasMain;

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject canvasPausa;

    [SerializeField] private GameObject botonAudio;
    [SerializeField] private GameObject canvasAudio;

    [SerializeField] private GameObject botonCreditos;
    [SerializeField] private GameObject canvasCreditos;

    [SerializeField] private GameObject botonAlonso;
    [SerializeField] private GameObject canvasAlonso;
    public void Pause()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        canvasPausa.SetActive(true);
    }
    public void Audio()
    {
        Time.timeScale = 0f;
        botonAudio.SetActive(false);
        canvasAudio.SetActive(true);
    }
    public void Creditos()
    {
        Time.timeScale = 0f;
        canvasMain.SetActive(false);
        //botonCreditos.SetActive(false);
        canvasCreditos.SetActive(true);
    }
    
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        canvasPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Cerrar()
    {
        Application.Quit();
    }
    public void CerrarPanelAudio()
    {
        Time.timeScale = 1f;
        canvasAudio.SetActive(false);
        botonAudio.SetActive(true);
    }
    public void CerrarPanelCreditos()
    {
        Time.timeScale = 1f;
        canvasCreditos.SetActive(false);
        canvasMain.SetActive(true);
        //botonCreditos.SetActive(true);
    }

    public void Alonso()
    {
        botonCreditos.SetActive(false);
        canvasCreditos.SetActive(true);
    }
    //public void CerrarPanelAlonso()
    //{
    //    botonAlonso.SetActive(false);
    //    canvasAlonso.SetActive(true);
    //}
}
