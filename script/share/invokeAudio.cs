using UnityEngine;
using System.Collections;

public class invokeAudio : MonoBehaviour
{
    public int InvokeTime;
    void OnEnable()
    {
        Invoke("PlaySound", InvokeTime);
    }
    private void PlaySound()
    {
        this.audio.Play();
    }
}
