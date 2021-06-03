using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeControl : MonoBehaviour
{
    public bool enrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            enrange = true;
            //PlayerPrefs.SetInt("enemyrange",1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            enrange = false;
            //PlayerPrefs.SetInt("enemyrange", 0);
        }
    }
}
