using UnityEngine;

public class AudioBTTNS : MonoBehaviour
{
    public AudioSource audioManager;
    public AudioClip Accept, Click, Denied, Construccion,  Countdown;

    public void ClickBTTN()
    {
        audioManager.clip = Click;
        audioManager.Play();
    }
    public void AcceptBTTN()
    {
        audioManager.clip = Accept;
        audioManager.Play();
    }
    public void DenyBTTN()
    {
        audioManager.clip = Denied;
        audioManager.Play();
    }
    public void ConstruccionBTTN()
    {
        audioManager.clip = Construccion;
        audioManager.Play();
    }
    public void CountdownBTTN()
    {
        audioManager.clip = Countdown;
        audioManager.Play();
    }

}
