using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("FPS"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
