using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{

    public void Menu()
    {
        //Carga el juego.
        SceneManager.LoadScene(0);

    }
    public void Iniciar()
    {
        //Carga el juego.
        SceneManager.LoadScene(1);

    }
    public void Turorial()
    {
        //Carga el Turorial.
        SceneManager.LoadScene(2);

    }
    public void Extras()
    {
        //Carga el Turorial.
        SceneManager.LoadScene(3);

    }

    public void Finalizar()
    {
        //Finaliza la aplicacion.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
