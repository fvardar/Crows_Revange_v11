using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject PlayPanel;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject Level4Button;


    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (PlayerPrefs.GetInt("Level") == 4)
        {
            Level1Button.SetActive(true);
            Level2Button.SetActive(true);
            Level3Button.SetActive(true);
            Level4Button.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") == 3)
        {
            Level1Button.SetActive(true);
            Level2Button.SetActive(true);
            Level3Button.SetActive(true);
            Level4Button.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            Level1Button.SetActive(true);
            Level2Button.SetActive(true);
            Level3Button.SetActive(false);
            Level4Button.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            Level1Button.SetActive(true);
            Level2Button.SetActive(false);
            Level3Button.SetActive(false);
            Level4Button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Play_Scene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PlayLevel1_Scene()
    {
        if (PlayerPrefs.GetInt("Level") >= 1)
        {
            PlayPanel.SetActive(false);
            SceneManager.LoadScene("GameScene");
        }  
    }
    public void PlayLevel2_Scene()
    {
        if (PlayerPrefs.GetInt("Level") >= 2)
        {
            PlayPanel.SetActive(false);
            SceneManager.LoadScene("Level2");
        }
    }
    public void PlayLevel3_Scene()
    {
        if (PlayerPrefs.GetInt("Level") >= 3)
        {
            PlayPanel.SetActive(false);
            SceneManager.LoadScene("Level3");
        }
    }
    public void PlayLevel4_Scene()
    {
        if (PlayerPrefs.GetInt("Level") >= 4)
        {
            PlayPanel.SetActive(false);
            SceneManager.LoadScene("Level4");
        }
    }

    public void Exit_Scene()
    {
        Application.Quit();
    }
    public void Settings_Scene()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Menu_Scene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Inventory_Scene()
    {
        SceneManager.LoadScene("Inventory");
    }
    public void AR_Scene()
    {
        SceneManager.LoadScene("ARPart");
    }
    public void WithoutAR_Scene()
    {
        SceneManager.LoadScene("WithoutArMaze");
    }
    
}
