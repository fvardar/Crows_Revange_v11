using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithoutARBall : MonoBehaviour
{
	public GameObject _plane;
	public GameObject _respawn;

	Rigidbody rb;
	[Range(0.2f, 2f)]
	public float moveSpeedModifier = 0.5f;
	float dirX, dirY;
	static bool moveAllowed;

	bool win_state;
	public GameObject wintext;

	void Start()
	{
		Time.timeScale = 1;
		moveAllowed = true;
		rb = GetComponent<Rigidbody>();
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Update is called once per frame
	void Update()
	{
		dirX = Input.acceleration.x * moveSpeedModifier;
		dirY = Input.acceleration.y * moveSpeedModifier;

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

	void FixedUpdate()
	{
		if (moveAllowed)
			rb.velocity = new Vector3(rb.velocity.x + dirY, rb.velocity.y, rb.velocity.z - dirX);
		if (transform.position.y < _plane.transform.position.y)
		{
			transform.position = _respawn.transform.position;
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
