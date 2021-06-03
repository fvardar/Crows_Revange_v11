using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void _ExitGame()
    {
        Application.Quit();
    }
    public void _NextLevel()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            PlayerPrefs.SetInt("Level", 2);
        }
        SceneManager.LoadScene("Menu");   
    }
    public void _NextLevel2()
    {
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            PlayerPrefs.SetInt("Level", 3);
        }
        SceneManager.LoadScene("Menu");
    }
    public void _NextLevel3()
    {
        if (PlayerPrefs.GetInt("Level") == 3)
        {
            PlayerPrefs.SetInt("Level", 4);
        }
        SceneManager.LoadScene("Menu");
    }
    public void _AR_Scene()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            PlayerPrefs.SetInt("Level", 2);
        }
        SceneManager.LoadScene("ARPart");
    }
    public void _WithoutAR_Scene()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            PlayerPrefs.SetInt("Level", 2);
        }
        SceneManager.LoadScene("WithoutArMaze");
    }
    public void _AR_Scene2()
    {
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            PlayerPrefs.SetInt("Level", 3);
        }
        SceneManager.LoadScene("ARPart");
    }
    public void _WithoutAR_Scene2()
    {
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            PlayerPrefs.SetInt("Level", 3);
        }
        SceneManager.LoadScene("WithoutArMaze");
    }
    public void _AR_Scene3()
    {
        if (PlayerPrefs.GetInt("Level") == 3)
        {
            PlayerPrefs.SetInt("Level", 4);
        }
        SceneManager.LoadScene("ARPart");
    }
    public void _WithoutAR_Scene3()
    {
        if (PlayerPrefs.GetInt("Level") == 3)
        {
            PlayerPrefs.SetInt("Level", 4);
        }
        SceneManager.LoadScene("WithoutArMaze");
    }
    public void _RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void _Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
