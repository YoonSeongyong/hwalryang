using UnityEngine;
using System.Collections;

public class endingscenetouch : MonoBehaviour {
    public GUIText t, g;
	// Use this for initialization
	void Start () {
        GPGSUnityPlugin.ShowLeaderboard("CgkIrcm2nLQfEAIQBg");
        t.fontSize = Mathf.CeilToInt(Screen.width / 15f);
        g.fontSize = Mathf.CeilToInt(Screen.width / 25f);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            Application.LoadLevelAsync("TitleScene");
            totalmgr.isend = false;
            totalmgr.score = 0;
        }
	}
}
