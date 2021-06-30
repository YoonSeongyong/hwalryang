using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject magnum_arrow;
    public GameObject bow;
    public GameObject Trajectory;
    public Animator shot_anim;
    public AudioClip clip,mag_s;
    public GUIText money;
    public static bool magnum_skill_flag, multi_skill_flag;
    // Use this for initialization
    void Awake()
    {
        totalmgr.WallHP = 100f;
        totalmgr.money = 10;
        totalmgr.price = new int[3];
        totalmgr.isend = false;
        magnum_skill_flag = false;
        multi_skill_flag = false;
        for (int i = 0; i < totalmgr.price.Length; i++)
        {
            totalmgr.price[i] = 100;
        }
    }
    void Start()
    {
        shot_anim.SetBool("Shot", true);
        totalmgr.Stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().speed = GameManager.shootspeed;
        money.text = totalmgr.money.ToString() + "냥";
        if (SkillScript.Use_Skill == true)
        {
            shot_anim.SetBool("Shot", false);
            Trajectory.SetActive(true);
        }
        else if (SkillScript.Use_Skill == false)
        {
            Trajectory.SetActive(false);
            shot_anim.SetBool("Shot", true);
        }
    }

    void Shot()
    {
        if (magnum_skill_flag)
        {
            GameObject tt = Instantiate(magnum_arrow, bow.transform.position, bow.transform.rotation) as GameObject;
            tt.SendMessage("setdamage", GameManager.damage * 3f);
            AudioSource.PlayClipAtPoint(mag_s, Vector3.zero);
            return;
        }
        if (multi_skill_flag)
        {
            GameObject ttt = Instantiate(arrow, bow.transform.position, bow.transform.rotation) as GameObject;
            ttt.SendMessage("setdamage", GameManager.damage * 0.7f);
            ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + 5))) as GameObject;
            ttt.SendMessage("setdamage", GameManager.damage * 0.6f);
            ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + 10))) as GameObject;
            ttt.SendMessage("setdamage", GameManager.damage * 0.5f);
            ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z - 5))) as GameObject;
            ttt.SendMessage("setdamage", GameManager.damage * 0.6f);
            ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z - 10))) as GameObject;
            ttt.SendMessage("setdamage", GameManager.damage * 0.5f);
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            return;
        }
        GameObject t = Instantiate(arrow, bow.transform.position, bow.transform.rotation) as GameObject;
        t.SendMessage("setdamage", GameManager.damage);
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }

    void pershot()
    {
        int t = Random.Range(1, 101);
        if (magnum_skill_flag)
        {
            magnum_skill_flag = false;
            if (t > 100 - GameManager.persent / 2)
            {
                GameObject tm = Instantiate(magnum_arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + Random.Range(-5f, 5f)))) as GameObject;
                tm.SendMessage("setdamage", GameManager.damage * 2f);
                AudioSource.PlayClipAtPoint(mag_s, Vector3.zero);
            }
            return;
        }
        if (multi_skill_flag)
        {
            multi_skill_flag = false;
            if (t > 100 - GameManager.persent/2)
            {
                float rand = Random.Range(-10f, 10f);
                GameObject ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + rand))) as GameObject;
                ttt.SendMessage("setdamage", GameManager.damage * 0.5f);
                ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + 5 + rand))) as GameObject;
                ttt.SendMessage("setdamage", GameManager.damage * 0.45f);
                ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + 10 + rand))) as GameObject;
                ttt.SendMessage("setdamage", GameManager.damage * 0.4f);
                ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z - 5 + rand))) as GameObject;
                ttt.SendMessage("setdamage", GameManager.damage * 0.45f);
                ttt = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z - 10 +rand))) as GameObject;
                ttt.SendMessage("setdamage", GameManager.damage * 0.4f);
                AudioSource.PlayClipAtPoint(clip, Vector3.zero);
                AudioSource.PlayClipAtPoint(clip, Vector3.zero);
                AudioSource.PlayClipAtPoint(clip, Vector3.zero);
                return;
            }
        }
        if (t > 100 - GameManager.persent)
        {
            GameObject tm = Instantiate(arrow, bow.transform.position, Quaternion.Euler(new Vector3(bow.transform.rotation.eulerAngles.x, bow.transform.rotation.eulerAngles.y, bow.transform.rotation.eulerAngles.z + Random.Range(-20f, 20f)))) as GameObject;
            tm.SendMessage("setdamage", GameManager.damage * 0.5f);
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        }
    }

}
