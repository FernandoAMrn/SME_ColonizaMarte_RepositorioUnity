using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasPanels : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject botonAudio;
    [SerializeField] private GameObject menuAudio;

    [SerializeField] private GameObject botonCreditos;
    [SerializeField] private GameObject menuCreditos;
    public void Pause()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Audio()
    {
        Time.timeScale = 0f;
        botonAudio.SetActive(false);
        menuAudio.SetActive(true);
    }
    public void Creditos()
    {
        Time.timeScale = 0f;
        botonCreditos.SetActive(false);
        menuCreditos.SetActive(true);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
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
        menuAudio.SetActive(false);
        botonAudio.SetActive(true);
    }
    public void CerrarPanelCreditos()
    {
        menuCreditos.SetActive(false);
        botonCreditos.SetActive(true);
    }
}
