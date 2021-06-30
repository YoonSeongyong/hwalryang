using UnityEngine;
using System.Collections;

public class attackrange : MonoBehaviour {
    public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Wall")
        {
            parent.SendMessage("attackstart", SendMessageOptions.DontRequireReceiver);
        }
    }
}
