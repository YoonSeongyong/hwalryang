using UnityEngine;
using System.Collections;

public class wavemove : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - (speed*Time.deltaTime), gameObject.transform.position.y, gameObject.transform.position.z);
        if(gameObject.transform.position.x<-110f)
        {
            gameObject.transform.position = new Vector3(110f, -39f, gameObject.transform.position.z);
        }
	}
}
