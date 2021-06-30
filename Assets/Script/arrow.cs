using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {
    private Rigidbody2D t;
    private float firstangle;
    public float damage;
	// Use this for initialization
	void Start () {
        t = gameObject.GetComponent<Rigidbody2D>();
        firstangle=gameObject.transform.rotation.eulerAngles.z;
        t.velocity = new Vector2(Mathf.Cos(gameObject.transform.rotation.eulerAngles.z*Mathf.Deg2Rad) * 160f, Mathf.Sin(gameObject.transform.rotation.eulerAngles.z*Mathf.Deg2Rad) * 160f);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2(t.velocity.y, t.velocity.x)*Mathf.Rad2Deg));

        if (gameObject.transform.position.y < -100.0f)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x > 90.0f)
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
        if(coll.tag=="RedOni"||coll.tag=="BlueWisp"||coll.tag=="BlueOni"||coll.tag=="GreenOni"||coll.tag=="GreenWisp"||coll.tag=="RedWisp")
        {
            coll.SendMessage("damaged", damage);
            Destroy(gameObject);
        }
    }
}
