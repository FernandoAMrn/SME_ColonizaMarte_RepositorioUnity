using UnityEngine;

public class PauseBTTN : MonoBehaviour
{
    //Atributos
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

    [SerializeField] private GameObject botonAudio;
    [SerializeField] private GameObject canvasAudio;

    public void Audio()
    {
        Time.timeScale = 0f;
        botonAudio.SetActive(false);
        canvasAudio.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);

    }
    public void Resume()
    {
        Time.timeScale = 1;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);

    }
    public void CerrarPanelAudio()
    {
        Time.timeScale = 0f;
        canvasAudio.SetActive(false);
        botonAudio.SetActive(true);
    }


}
