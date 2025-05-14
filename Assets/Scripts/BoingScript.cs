using UnityEngine;

public class BoingScript : MonoBehaviour
{
    public AudioSource alarmAudio;
    public AudioClip collisionSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (alarmAudio != null && !alarmAudio.isPlaying)
            {
                alarmAudio.Play();
                Debug.Log("Alarm triggered!");
            }
        }
    }
}