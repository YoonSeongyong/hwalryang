using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    float Bullet_Speed;
	// Use this for initialization
	void Start () {
        Bullet_Speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - Bullet_Speed, gameObject.transform.position.y, gameObject.transform.position.z);
        Bullet_Speed += 0.05f;
        if (gameObject.transform.position.x < -75.0f)
        {
            Destroy(gameObject);
        }
    }

}
