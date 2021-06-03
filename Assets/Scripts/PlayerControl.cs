using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerControl : MonoBehaviour
{
    public Image Bar_2;
    public TextMeshProUGUI Health_Count;
    Transform Ch;
    private PlayerController pac;
    [SerializeField] private float speed, jumpSpeed,egilme;
    private Rigidbody2D rb;
    public bool walkr;
    public bool walkl;
    public bool _egil;
    Animator CharacterAnim;
    private bool trapstate;

    [SerializeField] private LayerMask ground;
    private PolygonCollider2D col;
    public bool Isgro = false;
    public float moveinput;
    public float Player_Health = 10;

    public GameObject DeadPanel;
    public GameObject WinPanel;
    private bool deadbool;

    private void Awake()
    {
        pac = new PlayerController();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
        Ch = transform.GetChild(0);
        PlayerPrefs.SetInt("Health", 2);
        CharacterAnim = gameObject.GetComponent<Animator>();
        PlayerPrefs.SetFloat("DeadCount",0);
    }

    private void OnEnable()
    {
        pac.Enable();
    }
    private void OnDisable()
    {
        pac.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        pac.Land.Jump.performed += _ => Jump();
        pac.Land.Egil.performed += _ => aegil();
        
    }
    public void aegil()
    {
        _egil = true;
    }
    public void kalk()
    {
        _egil = false;
        CharacterAnim.Play("Player_Kalk");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Barrier")
        {
            Isgro = true;
        }
        if (collision.transform.name == "Door")
        {
            deadbool = true;
        }
        if (collision.transform.tag == "Trap")
        {
            trapstate = true;
            Isgro = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Barrier")
        {
            Isgro = true;
        }
        if (collision.transform.tag == "Trap")
        {
            trapstate = true;
            Isgro = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Barrier")
        {
            Isgro = false;
        }
        if (collision.transform.name == "Door")
        {
            deadbool = false;
        }
        if (collision.transform.tag == "Trap")
        {
            trapstate = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Health")
        {
            Player_Health = 10;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Health")
        {
            Isgro = true;
        }
    }
    public void Jump()
    {
        if (Isgro)
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            Isgro = false;
            SoundManager.PlaySound("jump");
        }
    }
    public void Rwalk()
    {
        walkr = true;
        SoundManager.WalkSound();
        PlayerPrefs.SetFloat("moveinput", 1f);
    }
    public void Rwalkex()
    {
        walkr = false;
        SoundManager.StopWalk();
        CharacterAnim.Play("Player_Anims");
    }
    public void Lwalk()
    {
        walkl = true;
        SoundManager.WalkSound();
        PlayerPrefs.SetFloat("moveinput", -1f);
    }
    public void Lwalkex()
    {
        walkl = false;
        SoundManager.StopWalk();
        CharacterAnim.Play("Player_Anims");
    }

    public void Walk()
    {
        moveinput = pac.Land.Sideways.ReadValue<float>();
        if (moveinput == -1)
        {
            Ch.rotation = Quaternion.Euler(0, 180, 0);
            PlayerPrefs.SetInt("yonn", 180);
        }
        else if (moveinput == 1)
        {
            Ch.rotation = Quaternion.Euler(0, 0, 0);
            PlayerPrefs.SetInt("yonn", 0);
        }
        Vector3 currentPos = transform.position;
        currentPos.x += moveinput * speed * Time.deltaTime;
        transform.position = currentPos;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        Walk();
        Trapcontrol();
        if (_egil)
        {
            CharacterAnim.Play("Player_Egil");
        }

        if(walkr == true)
        {
            CharacterAnim.Play("Player_Run");
            Ch.rotation = Quaternion.Euler(0, 0, 0);
            PlayerPrefs.SetInt("yonn", 0);
            Vector3 currentPos = transform.position;
            currentPos.x += 1f * speed * Time.deltaTime;
            transform.position = currentPos;
        }
        if (walkl == true)
        {
            CharacterAnim.Play("Player_Run");
            Ch.rotation = Quaternion.Euler(0, 180, 0);
            PlayerPrefs.SetInt("yonn", 180);
            Vector3 currentPos = transform.position;
            currentPos.x += -1f * speed * Time.deltaTime;
            transform.position = currentPos;
        }
       // Ch.rotation = Quaternion.Euler(0, PlayerPrefs.GetInt("yonn"), 0); "durduğunda çalışcak kod
        IsAlived();
        if (PlayerPrefs.GetFloat("DeadCount") == 4)
        {
            if (deadbool == true)
            {
                // int level = PlayerPrefs.GetInt("Level");
                // level++;
                // PlayerPrefs.SetInt("Level",level);
                WinPanel.SetActive(true);
            }
        }
    }
    void IsAlived()
    {
        Bar_2.GetComponent<Image>().fillAmount = Player_Health / 10;
        Health_Count.text = (Player_Health * 10).ToString("0");
        if (Player_Health <= 0)
        {
            DeadPanel.SetActive(true);
        }
    } 
    void Trapcontrol()
    {
        if (trapstate)
        {
            Player_Health -= Time.deltaTime;
            Bar_2.GetComponent<Image>().fillAmount = Player_Health;
        }
    }
}
