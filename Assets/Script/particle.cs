using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {
    public Renderer t;
	// Use this for initialization
	void Start () {
        t.sortingLayerName = "object";
        t.sortingOrder = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
