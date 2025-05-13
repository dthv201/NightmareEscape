using UnityEngine;

public class DoorAlarmTrigger : MonoBehaviour
{
    public AudioSource alarmAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (alarmAudio != null && !alarmAudio.isPlaying)
            {
                alarmAudio.Play();
                Debug.Log("Alarm triggered!");
            }
        }
    }
}
