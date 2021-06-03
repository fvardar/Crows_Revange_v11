using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBall : MonoBehaviour
{

    public GameObject _plane;
    public bool win_state;
    public GameObject _spawnpoint;
    public GameObject wintext;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        win_state = false;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < _plane.transform.position.y - 10)
        {
            transform.position = _spawnpoint.transform.position;
        }

        if (win_state)
        {
            if(PlayerPrefs.GetInt("Level") == 2)
            {
                PlayerPrefs.SetInt("Maze",1);
            }
            if(PlayerPrefs.GetInt("Level") == 3)
            {
                PlayerPrefs.SetInt("Maze",2);
            }
            if(PlayerPrefs.GetInt("Level") == 4)
            {
                PlayerPrefs.SetInt("Maze",3);
            }
            wintext.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Win")
        {
            win_state = true;
        }
    }
}

