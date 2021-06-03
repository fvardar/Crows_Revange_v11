using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _ExitGame()
    {
        Application.Quit();
    }
    public void _RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void _RestartGame2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void _RestartGame3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void _RestartGame4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void _Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void _Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
