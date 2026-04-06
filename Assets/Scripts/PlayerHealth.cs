using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public Image[] hearts; 
    public GameObject gameOverPanel;
    public GameObject gamePanel;


    public void TakeDamage()
    {
        if (health <= 0) return;

        health--;

       
        if (health < hearts.Length)
        {
            hearts[health].enabled = false;
        }

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("GAME OVER!");
    }
}
