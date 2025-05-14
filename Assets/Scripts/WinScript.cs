using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public AudioSource alarmAudio;
    [SerializeField] string sceneToLoad = "Win"; // set your scene name here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (alarmAudio != null && !alarmAudio.isPlaying)
            {
                alarmAudio.Play();
                Debug.Log("Alarm triggered!");
            }
            SceneManager.LoadScene(sceneToLoad);
        }
         
    }
}
