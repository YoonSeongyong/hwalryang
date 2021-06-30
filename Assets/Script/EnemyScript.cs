using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    /*
     몬스터의 체력, 공격력, 이동속도, 공격 쿨타임, 몬스터 종류
     */
    public float HP,MAXHP;
    public float Damage;
    public float Speed;
    public float CoolTime;
    public bool isattack;
    public GameObject particle;
    public GameObject particle2;
    public GameObject particlepos;
    public GameObject lifebar;
    public AudioClip die,damagedsound,wallattacksound;
    public bool maghit; 

    private float nowcooltime;
    // Use this for initialization
    void Start()
    {
        nowcooltime = 0;
        maghit = false;
        isattack = false;
        /*
         * 
         */
        switch (gameObject.transform.tag)
        {
            case "RedOni":
                HP = 4f + totalmgr.Stage * 2f;
                Damage = 1f + totalmgr.Stage/2;
                Speed = 8;
                CoolTime = 1.5f;
                break;
            case "BlueOni":
                HP = 7f + totalmgr.Stage * 2.5f;
                Damage = 0.5f + totalmgr.Stage/2;
                Speed = 4;
                CoolTime = 2.5f;
                break;
            case "GreenOni":
                HP = 3f + totalmgr.Stage * 1f;
                Damage = 5f + totalmgr.Stage/2;
                Speed = 10;
                CoolTime = 5.0f;
                break;

            case "BlueWisp":
                HP = 3f + totalmgr.Stage * 1.5f;
                Damage = 1.5f + totalmgr.Stage/2;
                Speed = 6;
                CoolTime = 2.0f;
                break;
            case "RedWisp":
                HP = 2.5f + totalmgr.Stage * 1.5f;
                Damage = 1.0f + totalmgr.Stage/2;
                Speed = 12;
                CoolTime = 2.5f;
                break;
            case "GreenWisp":
                HP = 4f + totalmgr.Stage * 2f;
                Damage = 1f + totalmgr.Stage/2;
                Speed = 8;
                CoolTime = 1.5f;
                break;

        }

        if(totalmgr.isend)
        {
            Speed = 30f;
        }
        MAXHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.transform.localScale = new Vector3(HP / MAXHP, 1, 1);
        if(isattack)
        {
            nowcooltime += Time.deltaTime;
            if(nowcooltime>CoolTime)
            {
                gameObject.GetComponent<Animator>().SetBool("attack", true);
                nowcooltime = 0f;
            }
        }
        else
        {
            gameObject.transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    void attack()
    {
        totalmgr.WallHP -= Damage;
        AudioSource.PlayClipAtPoint(wallattacksound, Vector3.zero);
        Debug.Log(totalmgr.WallHP);
    }

    void attackcooltime()
    {
        gameObject.GetComponent<Animator>().SetBool("attack", false);
    }

    void damaged(float dam)
    {
        if (maghit && dam > GameManager.damage)
        {
            return;
        }
        else if (dam > GameManager.damage)
        {
            Instantiate(particle2, particlepos.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(particle, particlepos.transform.position, Quaternion.identity);
        }
        HP -= dam;
        
        AudioSource.PlayClipAtPoint(damagedsound, Vector3.zero);
        if(HP<=0)
        {
            AudioSource.PlayClipAtPoint(die, Vector3.zero);
            totalmgr.money += 10 + (totalmgr.Stage * totalmgr.Stage);
            totalmgr.score += 10 + (totalmgr.Stage * totalmgr.Stage);
            Destroy(gameObject);
        }
    }

    void attackstart()
    {
        isattack = true;
        gameObject.GetComponent<Animator>().SetBool("attack", true);
    }

    void DamagebyMag()
    {
        maghit = true;
        Invoke("ResetHit", 1.0f);
    }

    void ResetHit()
    {
        maghit = false;
    }
}
