using UnityEngine;
using System.Collections;

public class SkillScript : MonoBehaviour
{
    public static bool Use_Skill;
    float cooltime, mag_cooltime_now, mul_cooltime_now;
    public Camera maincamera;
    public GameObject Magnum, Multi, MagnumCooltime, MultiCooltime;//1:매그넘, 2:멀티샷
    Vector2 tap_icon, origin_icon;
    public Animator anim;
    private bool canshot;
    public GameObject mag_canuse, mul_canuse;
    // Use this for initialization
    void Start()
    {
        cooltime = 20.0f;
        mag_cooltime_now = 0f;
        mul_cooltime_now = 0f;
        origin_icon = Magnum.transform.localScale;
        tap_icon = Magnum.transform.localScale - (Magnum.transform.localScale / 10f);
        Use_Skill = false;
        MagnumCooltime.transform.localScale = new Vector3(7.8f, 0, 1);
        MultiCooltime.transform.localScale = new Vector3(7.8f, 0, 1);
        Magnum.transform.localScale = (Vector3)origin_icon;
        canshot = false;
        mag_canuse.SetActive(false);
        mul_canuse.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(maincamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.tag == "Skill_Magnum")
                {
                    if (mag_cooltime_now > cooltime)
                    {
                        if (!canshot)
                        {
                            Magnum.transform.localScale = tap_icon;
                            Use_Skill = true;
                        }
                        else if (canshot)
                        {
                            Use_Skill = false;
                            canshot = false;
                            PlayerScript.magnum_skill_flag = true;
                            Magnum.transform.localScale = origin_icon;
                            mag_cooltime_now = 0;
                        }
                    }
                }
                if (hit.collider != null && hit.collider.tag == "Skill_Multi")
                {
                    if (mul_cooltime_now > 7)
                    {
                        Multi.transform.localScale = tap_icon;
                        StartCoroutine(restartanimation());
                        PlayerScript.multi_skill_flag = true;
                        mul_cooltime_now = 0;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(maincamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.tag == "Skill_Magnum")
                {
                    if (Use_Skill)
                    {
                        if (mag_cooltime_now > cooltime)
                        {
                            canshot = true;
                        }
                    }
                }
                Multi.transform.localScale = origin_icon;
            }


        }
        #endregion
        #region Touch
        else
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if(t.phase==TouchPhase.Began)
                {
                    RaycastHit2D hit = Physics2D.Raycast(maincamera.ScreenToWorldPoint(t.position), Vector2.zero);
                    if (hit.collider != null && hit.collider.tag == "Skill_Magnum")
                    {
                        if (mag_cooltime_now > cooltime)
                        {
                            if (!canshot)
                            {
                                Magnum.transform.localScale = tap_icon;
                                Use_Skill = true;
                            }
                            else if (canshot)
                            {
                                Use_Skill = false;
                                canshot = false;
                                PlayerScript.magnum_skill_flag = true;
                                Magnum.transform.localScale = origin_icon;
                                mag_cooltime_now = 0;
                            }
                        }
                    }
                    if (hit.collider != null && hit.collider.tag == "Skill_Multi")
                    {
                        if (mul_cooltime_now > 7)
                        {
                            Multi.transform.localScale = tap_icon;
                            StartCoroutine(restartanimation());
                            PlayerScript.multi_skill_flag = true;
                            mul_cooltime_now = 0;
                        }
                    }
                }
                else if (t.phase == TouchPhase.Ended)
                {
                    RaycastHit2D hit = Physics2D.Raycast(maincamera.ScreenToWorldPoint(t.position), Vector2.zero);
                    if (hit.collider != null && hit.collider.tag == "Skill_Magnum")
                    {
                        if (Use_Skill)
                        {
                            if (mag_cooltime_now > cooltime)
                            {
                                canshot = true;
                            }
                        }
                    }
                    Multi.transform.localScale = origin_icon;
                }
            }
        }
        #endregion

        MagnumCooltime.transform.localScale = new Vector3(7.8f, Mathf.Lerp(7.8f, 0, mag_cooltime_now / cooltime), 1);
        MultiCooltime.transform.localScale = new Vector3(7.8f, Mathf.Lerp(7.8f, 0, mul_cooltime_now / 7), 1);
        mag_cooltime_now += Time.deltaTime;
        mul_cooltime_now += Time.deltaTime;
        if(mag_cooltime_now>cooltime)
        {
            mag_canuse.SetActive(true);
        }
        else
        {
            mag_canuse.SetActive(false);
        }
        if(mul_cooltime_now>7)
        {
            mul_canuse.SetActive(true);
        }
        else
        {
            mul_canuse.SetActive(false);
        }
    }

    IEnumerator restartanimation()
    {
        anim.SetBool("Shot", false);
        yield return new WaitForEndOfFrame();
        anim.SetBool("Shot", true);
    }
}
