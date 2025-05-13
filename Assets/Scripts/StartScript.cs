using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
     public GameObject descriptionPanel; 
    public bool loadNextScene = false; 

    public void ClosePanelAndStart()
    {
        descriptionPanel.SetActive(false);

        if (loadNextScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
 } 
