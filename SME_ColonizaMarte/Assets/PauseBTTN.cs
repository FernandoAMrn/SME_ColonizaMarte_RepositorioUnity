using UnityEngine;

public class PauseBTTN : MonoBehaviour
{
    //Atributos
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

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
}
