using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameObject winPanel;
    public GameObject gamePanel;
    public string enemyTag = "Enemy";
    private bool gameStarted = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Invoke("EnableEnemyCheck", 0.1f);
        gamePanel.SetActive(true);
    }
    void EnableEnemyCheck()
    {
        gameStarted = true;
    }
    void Update()
    {
        if (!gameStarted) return;
        

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

       
        if (enemies.Length == 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (winPanel.activeSelf) return;

        gamePanel.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0f; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Vittoria! Tutti i nemici eliminati.");
    }

    public void RestartGame()
    {
        gamePanel.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
