using UnityEngine;
using System.Collections;

public class TitleAnimScript : MonoBehaviour
{

    public GameObject arrow;
    public GameObject bow;
    public Animator shot_anim;
    public AudioClip clip;
    // Use this for initialization
    void Start()
    {
    }
    void Shot()
    {
        GameObject t = Instantiate(arrow, bow.transform.position, bow.transform.rotation) as GameObject;
        t.SendMessage("setdamage", GameManager.damage);
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().speed = GameManager.shootspeed;
        shot_anim.SetBool("Shot", true);
    }
}
