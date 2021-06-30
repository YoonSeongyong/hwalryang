using UnityEngine;
using System.Collections;

public class EnemyBulletShot : MonoBehaviour {
    public GameObject Enemy_Bullet;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    void Shot()
    {
        Instantiate(Enemy_Bullet, gameObject.transform.position, Quaternion.identity);
    }
}
