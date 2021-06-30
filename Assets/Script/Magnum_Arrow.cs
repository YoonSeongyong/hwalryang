using UnityEngine;
using System.Collections;

public class Magnum_Arrow : MonoBehaviour {
    public float damage;
	// Use this for initialization
	void Start () {
        Rigidbody2D t = gameObject.GetComponent<Rigidbody2D>();
        t.velocity = new Vector2(Mathf.Cos(gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * 100f, Mathf.Sin(gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * 100f);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -200.0f)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x > 180.0f)
        {
            Destroy(gameObject);
        }
	}
    void setdamage(float dam)
    {
        damage = dam;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "RedOni" || coll.tag == "BlueWisp" || coll.tag == "BlueOni" || coll.tag == "GreenOni" || coll.tag == "GreenWisp" || coll.tag == "RedWisp")
        {
            coll.SendMessage("damaged", damage);
            coll.SendMessage("DamagebyMag");
        }
    }
}
