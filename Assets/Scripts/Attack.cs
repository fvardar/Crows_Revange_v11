using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    private Transform Enemy_Collison;
    private Transform Boss_Collison;
    SpriteRenderer sprite;
    int x;
    public GameObject[] ArrowPrefap;
    public bool buttonstatearrow = false;
    public float ArrowSpeed;
    Animator CharacterAnim;

    public float DeadCount;

    private float arrowattacktimer;
    public Image[] ArrowButton;
    private float swordattacktimer;
    public Image[] swordButton;

    public int arrowchose;
    public int swordchose;

    public bool WinStage = false;
    // Start is called before the first frame update
    void Start()
    {

        CharacterAnim = gameObject.GetComponent<Animator>();
        PlayerPrefs.SetInt("Winstage", 0); //False
        arrowchose = PlayerPrefs.GetInt("arrowchose");
        swordchose = PlayerPrefs.GetInt("swordchose");

    }
    // Update is called once per frame
    void Update()
    {
        if (arrowchose == 1)
            iceattacktrue();
        else
            arrowattacktrue();
        if (swordchose == 1)
            swordattacktrue1();
        else
            swordattacktrue();
        arrowattacktimer -= Time.deltaTime;
        swordattacktimer -= Time.deltaTime;
        if (arrowattacktimer <= 0)
        {
            arrowattacktimer = 0;
        }

        swordattacktimer -= Time.deltaTime;
        if (swordattacktimer <= 0)
        {
            swordattacktimer = 0;
        }

        DeadCount = PlayerPrefs.GetFloat("DeadCount");
        if (DeadCount >= 4)
        {
            
            WinStage = true;
            PlayerPrefs.SetInt("Winstage", 1); //true
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Enemy_Collison = collision.transform;
        }
        if (collision.transform.tag == "Boss")
        {
            Boss_Collison = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Enemy_Collison = null;
        }
        if (collision.transform.tag == "Boss")
        {
            Boss_Collison = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Enemy_Collison = collision.transform;
        }
        if (collision.transform.tag == "Boss")
        {
            Boss_Collison = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Enemy_Collison = null;
        }
        if (collision.transform.tag == "Boss")
        {
            Boss_Collison = null;
        }
    }
    public void arrowattacktrue()
    {
        if (arrowattacktimer != 0)
        {
            ArrowButton[arrowchose].GetComponent<Image>().fillAmount += Time.deltaTime / 2;
        }
    }
    public void iceattacktrue()
    {
        if (arrowattacktimer != 0)
        {
            ArrowButton[arrowchose].GetComponent<Image>().fillAmount += Time.deltaTime / 3;
        }
    }
    public void swordattacktrue()
    {
        if (swordattacktimer != 0)
        {
            swordButton[swordchose].GetComponent<Image>().fillAmount += Time.deltaTime * 1.5f;
        }
    }
    public void swordattacktrue1()
    {
        if (swordattacktimer != 0)
        {
            swordButton[swordchose].GetComponent<Image>().fillAmount += Time.deltaTime;
        }
    }

    public void _arrowAttack()
    {
        if (arrowattacktimer <= 0)
        {
            SoundManager.PlaySound("fireball");
            float a = PlayerPrefs.GetFloat("moveinput");
            if (a != 0)
            {
                if (a == -1)
                {
                    CharacterAnim.Play("Player_Fireball");
                    Invoke("WaitForNoAttack", 0.5f);
                    GameObject arrow = Instantiate(ArrowPrefap[arrowchose], new Vector2(transform.position.x - 1.2f, transform.position.y), Quaternion.identity);
                    arrow.transform.rotation = Quaternion.Euler(0, 180, 0);
                    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(a * ArrowSpeed, 0f);
                    Destroy(arrow, 2f);
                    buttonstatearrow = false;
                }
                if (a == +1)
                {
                    CharacterAnim.Play("Player_Fireball");
                    Invoke("WaitForNoAttack", 0.5f);

                    GameObject arrow = Instantiate(ArrowPrefap[arrowchose], new Vector2(transform.position.x + 1.2f, transform.position.y), Quaternion.identity);
                    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(a * ArrowSpeed, 0f);
                    Destroy(arrow, 2f);
                    buttonstatearrow = false;
                }
            }
            if (arrowchose == 1)
            {
                arrowattacktimer = 3;//Cooldown
            }
            else
                arrowattacktimer = 2;
            ArrowButton[arrowchose].GetComponent<Image>().fillAmount = 0;
        }

    }
    public void _Attack()
    {
        if (swordattacktimer <= 0)
        {
            SoundManager.PlaySound("sword");
            if (swordchose == 0)
            {
                CharacterAnim.Play("Player_Melee_Attack");
                Invoke("WaitForNoAttack", 0.5f);
            }
            if (swordchose == 1)
            {
                CharacterAnim.Play("Player_Melee_Attack_2");
                Invoke("WaitForNoAttack", 0.7f);
            }
            //Enemy Sword Damage Control
            if (Enemy_Collison != null)
            {
                x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
                if (x != 0)
                {
                    if (swordchose == 1)
                    {
                        x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
                        Destroy(Enemy_Collison.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
                        Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth--;
                    }
                }

                x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
                Destroy(Enemy_Collison.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
                Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth--;

                if (x == 1)
                {
                    sprite = Enemy_Collison.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>();
                    sprite.color = Color.red;
                }
                if (x == 0)
                {
                    DeadCount++;
                    PlayerPrefs.SetFloat("DeadCount", DeadCount);
                }
            }
            //Boss Sword Damage Control
            else if (Boss_Collison != null)
            {
                x = Boss_Collison.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
                if (x != 0)
                {
                    if (swordchose == 1)
                    {
                        x = Boss_Collison.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
                        Destroy(Boss_Collison.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
                        Boss_Collison.transform.gameObject.GetComponent<BossControl>()._EnemyHealth--;
                    }
                }

                x = Boss_Collison.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
                Destroy(Boss_Collison.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
                Boss_Collison.transform.gameObject.GetComponent<BossControl>()._EnemyHealth--;

                if (x == 1)
                {
                    sprite = Boss_Collison.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>();
                    sprite.color = Color.red;
                }
                if (x == 0)
                {
                    DeadCount++;
                    PlayerPrefs.SetFloat("DeadCount", DeadCount);
                }
            }
            if (swordchose == 1)
            {
                swordattacktimer = 2f;//Cooldown
            }
            else
                swordattacktimer = 1.5f;
            swordButton[swordchose].GetComponent<Image>().fillAmount = 0;
        }
    }

    void WaitForNoAttack()
    {
        CharacterAnim.Play("Player_Anims");
    }
}
