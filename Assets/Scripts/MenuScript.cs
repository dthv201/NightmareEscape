using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Canvas QuitMenu;
    public Button startText;
    public Button exitText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuitMenu.enabled = false;

    }

    // Update is called once per frame
    public void ExitPress()
    {
        QuitMenu.enabled = true;
        startText.enabled= false;
        exitText.enabled= false;
    }

    public void noPress()
    {
        QuitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled= true;
    }

	public void StartLevel()
	{
        SceneManager.LoadScene("Game");
	}
   
    public void ExitGame()
    {
        Application.Quit();
    }
}
