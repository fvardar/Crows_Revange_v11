using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillSelector : MonoBehaviour
{
    public TextMeshProUGUI FireballText;
    public TextMeshProUGUI IceballText;
    public TextMeshProUGUI Sword1Text;
    public TextMeshProUGUI Sword2Text;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Maze") == 0) 
        {
            FireballText.color = new Color32(255,0, 0, 255);
            IceballText.color = new Color32(255,0, 0, 255);
            Sword2Text.color = new Color32(255,0, 0, 255);
        }
        if (PlayerPrefs.GetInt("Maze") == 1) 
        {
            FireballText.color = new Color32(255,255, 255, 255);
            IceballText.color = new Color32(255,0, 0, 255);
            Sword2Text.color = new Color32(255,0, 0, 255); 
        }
        if (PlayerPrefs.GetInt("Maze") == 2) 
        {
            FireballText.color = new Color32(255,255, 255, 255);
            IceballText.color = new Color32(255,255, 255, 255);
            Sword2Text.color = new Color32(255,0, 0, 255); 
        }
        if (PlayerPrefs.GetInt("Maze") == 3) 
        {
            FireballText.color = new Color32(255,255, 255, 255);
            IceballText.color = new Color32(255,255, 255, 255);
            Sword2Text.color = new Color32(255,255, 255, 255); 
        }
        if (PlayerPrefs.GetInt("arrowchose") == 0)
        {
            Fireball();
        } else if (PlayerPrefs.GetInt("arrowchose") == 1)
        {
            Iceball();
        }
        if (PlayerPrefs.GetInt("swordchose") == 0)
        {
            Sword1();
        }
        else if (PlayerPrefs.GetInt("swordchose") == 1)
        {
            Sword2();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fireball()
    {
        if(PlayerPrefs.GetInt("Maze") > 0)
        {
            PlayerPrefs.SetInt("arrowchose", 0);
            FireballText.color = new Color32(0,255, 0, 255);
            if (PlayerPrefs.GetInt("Maze") >1 )
            {
                IceballText.color = new Color32(255, 255, 255, 255);
            }
        }
        
    }
    public void Iceball()
    {
        if(PlayerPrefs.GetInt("Maze") > 1)
        {
            PlayerPrefs.SetInt("arrowchose", 1);
            FireballText.color = new Color32(255, 255, 255, 255);
            IceballText.color = new Color32(0, 255, 0, 255);
        }
        
    }
    public void Sword1()
    {
        PlayerPrefs.SetInt("swordchose", 0);
        Sword1Text.color = new Color32(0, 255, 0, 255);
        if (PlayerPrefs.GetInt("Maze") > 2) 
        {
            Sword2Text.color = new Color32(255, 255, 255, 255);
        } 
    }
    public void Sword2()
    {
        if(PlayerPrefs.GetInt("Maze") > 2)
        {
            PlayerPrefs.SetInt("swordchose", 1);
            Sword2Text.color = new Color32(0, 255, 0, 255);
            Sword1Text.color = new Color32(255, 255, 255, 255);
        }
        
    }

}
