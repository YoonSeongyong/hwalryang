using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
    float HP, MaxHP;
    public GameObject HP_bar;
    // Use this for initialization
	void Start () {
        HP = totalmgr.WallHP;
        MaxHP = HP;
	}
	
	// Update is called once per frame
	void Update () {
        HP = totalmgr.WallHP;
        HP_bar.transform.localScale = new Vector3(Mathf.Lerp(0,2.5f,HP/MaxHP), 1.5f, 1);
	}
}
