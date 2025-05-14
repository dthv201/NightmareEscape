using UnityEngine;

public class WinSoundScript : MonoBehaviour
{
    public AudioClip sceneAudio;

    void Start()
    {
        AudioSource.PlayClipAtPoint(sceneAudio, transform.position);
    }

}
