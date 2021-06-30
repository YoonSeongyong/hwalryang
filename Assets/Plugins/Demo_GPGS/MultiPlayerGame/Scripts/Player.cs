using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public TextMesh textmesh;
	void Start () {
		
	}
	void SetLabel(string labeltext){
		textmesh.text = labeltext;
	}
}
