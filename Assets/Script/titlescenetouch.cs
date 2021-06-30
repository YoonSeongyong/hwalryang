using UnityEngine;
using System.Collections;

public class titlescenetouch : MonoBehaviour {
    public GUIText t;
	// Use this for initialization
	void Start () {
        t.fontSize = Mathf.CeilToInt(Screen.width / 25f);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            Application.LoadLevelAsync("gamescene");
        }
	}
}
