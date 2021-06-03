using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCamFollow : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 7f, transform.position.z);
    }
}
