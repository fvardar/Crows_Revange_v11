using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ArrowPrefap;
    public bool enemyrang;
    public int _EnemyHealth = 2;
    Animator EnemyAnim;
    Transform EnemyTransform;
    public Transform[] Targets;
    public int Next_Index;
    public float speed;
    public float fark;
    private float direction;
    private bool deadmus = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("_enemyattack", 1f, 2f);
        EnemyAnim = gameObject.GetComponent<Animator>();
        EnemyTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        enemyrang = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<EnemyRangeControl>().enrange;
        fark = transform.position.x - Targets[Next_Index].position.x;
        if (_EnemyHealth <= -1 )
        {
            if (!deadmus)
            {
                DeadMusic();
                deadmus = true;
            }
            EnemyAnim.Play("Enemy_Dead");
            Invoke("Dead", 2f);
        }
        else
        {
            if(fark < 0)
        {
                direction = 1.5f;
                EnemyTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (fark > 0)
            {
                direction = -1.2f;
                EnemyTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (enemyrang == false)
            {
                _enemywalk();
                EnemyAnim.Play("Enemy_Walk");
            }
        }

    }
    public void _enemywalk()
    {
        if (Vector2.Distance(transform.position,Targets[Next_Index].position) >= 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Targets[Next_Index].position, speed * Time.deltaTime);
        }
        else if (Next_Index == Targets.Length - 1)
        {
            Next_Index = 0;
        }
        else
        {
            Next_Index += 1; 
        }
    }
    public void _enemyattack()
    {
        if (_EnemyHealth > -1)
        {
            if (enemyrang == true)
            {
                EnemyAnim.Play("Enemy_Attack");
                Invoke("WaitForNoAttack", 0.5f);
                GameObject arrow = Instantiate(ArrowPrefap, new Vector2(transform.position.x + direction, transform.position.y), Quaternion.identity);
                arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * 6f, 0f);
                Destroy(arrow, 2f);
                SoundManager.PlaySound("arrow");
            }
        }
    }

    void WaitForNoAttack()
    {
        EnemyAnim.Play("Enemy_Anims");
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    void DeadMusic()
    {
        SoundManager.PlaySound("death");
    }
}
