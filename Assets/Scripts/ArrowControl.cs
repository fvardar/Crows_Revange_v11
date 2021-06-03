using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArrowControl : MonoBehaviour
{
    private Transform Enemy_Collison;
    private Transform Player_Collison;
    private Transform Boss_Collision;
    public bool arrowstate = false;
    SpriteRenderer sprite;
    //public Image Bar_2; 
    int x;
    public float DeadCount;
    public int enemy_damage;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Enemy_Collison = collision.transform;
        }
        if (collision.transform.tag == "Boss")
        {
            Boss_Collision = collision.transform;
        }
        if (collision.transform.name == "Player")
        {
            Player_Collison = collision.transform;
        }
        if (collision.transform.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Angular Bow 
        float angel = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);

        DeadCount = PlayerPrefs.GetFloat("DeadCount");
        EnemyHealthControl();
        PlayerHealthControl();
        BossHealthControl();

    }
    void PlayerHealthControl()
    {
        if (Player_Collison != null)
        {
            //Player_Collison.transform.gameObject.GetComponent<PlayerControl>().Player_Health--;
            Player_Collison.transform.gameObject.GetComponent<PlayerControl>().Player_Health -= enemy_damage;
            Destroy(gameObject);
        }
    }
    void EnemyHealthControl()
    {
        if (Enemy_Collison != null)
        {
            int q = PlayerPrefs.GetInt("arrowchose");
            x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
            if (x != 0)
            {
                if (q == 1)
                {
                    x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
                    Destroy(Enemy_Collison.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
                    Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth--;
                }
            }

            x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
            Destroy(Enemy_Collison.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
            Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth--;
            x = Enemy_Collison.transform.gameObject.GetComponent<EnemyController>()._EnemyHealth;
            x = x + 1;
            if (x == 1)
            {
                sprite = Enemy_Collison.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>();
                sprite.color = Color.red;
            }
            if (x <= 0)
            {
                DeadCount++;
                PlayerPrefs.SetFloat("DeadCount", DeadCount);
            }
            Destroy(gameObject);
        }
    }
    void BossHealthControl()
    {
        if (Boss_Collision != null)
        {
            int q = PlayerPrefs.GetInt("arrowchose");
            x = Boss_Collision.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
            if (x != 0)
            {
                if (q == 1)
                {
                    x = Boss_Collision.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
                    Destroy(Boss_Collision.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
                    Boss_Collision.transform.gameObject.GetComponent<BossControl>()._EnemyHealth--;
                }
            }

            x = Boss_Collision.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
            Destroy(Boss_Collision.transform.GetChild(0).transform.GetChild(x + 1).gameObject);
            Boss_Collision.transform.gameObject.GetComponent<BossControl>()._EnemyHealth--;
            x = Boss_Collision.transform.gameObject.GetComponent<BossControl>()._EnemyHealth;
            x = x + 1;
            if (x == 1)
            {
                sprite = Boss_Collision.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>();
                sprite.color = Color.red;
            }
            if (x <= 0)
            {
                DeadCount++;
                PlayerPrefs.SetFloat("DeadCount", DeadCount);
            }
            Destroy(gameObject);
        }
    }
}
