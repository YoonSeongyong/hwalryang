using UnityEngine;
using System.Collections;

public class gpgs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GPGSUnityPlugin.StartPlay(true);
        GPGSUnityPlugin.StartConnections();
        GPGSUnityPlugin.BeginUserInitiatedSignIn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
