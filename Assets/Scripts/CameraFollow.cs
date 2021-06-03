
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    public GameObject FireballButton;
    public GameObject IceballButton;
    public GameObject Sword1Button;
    public GameObject Sword2Button;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("arrowchose") == 0)
        {
            FireballButton.SetActive(true);
            IceballButton.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("arrowchose") == 1)
        {
            IceballButton.SetActive(true);
            FireballButton.SetActive(false);
        }
        if (PlayerPrefs.GetInt("swordchose") == 0)
        {
            Sword1Button.SetActive(true);
            Sword2Button.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("swordchose") == 1)
        {
            Sword2Button.SetActive(true);
            Sword1Button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
