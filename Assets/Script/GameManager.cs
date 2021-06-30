using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject[] nearmon, farmon;
    public GameObject summonpos;
    public float regentime, nowtime;
    private int summonnum, nowsummonnum;
    public GUIText stagetext;
    public static float damage;
    public static int persent;
    public static float shootspeed;
	// Use this for initialization

    void Awake()
    {
        regentime = 5f;
        nowtime = 0;
        summonnum = 5;
        nowsummonnum = 0;
        damage = 1;
        persent = 10;
        shootspeed = 1;
    }
	void Start () {
        if(totalmgr.isend)
        {
            regentime = 0.3f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (totalmgr.WallHP <= 0)
        {
            GPGSUnityPlugin.SubmitScore("CgkIrcm2nLQfEAIQBg", totalmgr.score);
            Application.LoadLevelAsync("endingscene");
            totalmgr.WallHP = 1;
            totalmgr.isend = true;
        }
        if(!totalmgr.isend)
        {
            regentime = 5 - 0.2f * (float)(totalmgr.Stage - 1);
            stagetext.text = totalmgr.Stage + "단계";
        }
        
        nowtime += Time.deltaTime;
        if(regentime<nowtime)
        {
            nowsummonnum++;
            int tem = Random.Range(0, 2);
            switch(tem)
            {
                case 0:
                    Instantiate(nearmon[Random.Range(0,nearmon.Length)], new Vector2(summonpos.transform.position.x,summonpos.transform.position.y+Random.Range(-12f,12f)), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(farmon[Random.Range(0, nearmon.Length)], new Vector2(summonpos.transform.position.x, summonpos.transform.position.y + Random.Range(-12f, 12f)), Quaternion.identity);
                    break;
            }
            nowtime = 0;
            if(nowsummonnum>=summonnum)
            {
                totalmgr.Stage++;
                summonnum++;
                nowsummonnum = 0;
            }
        }
	}
}
