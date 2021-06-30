using UnityEngine;
using System.Collections;

public class fontsizemanager : MonoBehaviour {
    public GUIText[] t;
	// Use this for initialization
	void Start () {
	    for(int i=0;i<t.Length;i++)
        {
            t[i].fontSize = Mathf.CeilToInt(Screen.width / 25f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
