using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("arrowchose", -1);
        PlayerPrefs.SetInt("swordchose", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Maze",0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
