using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class MultiPlayerGame : MonoBehaviour {
	public GUISkin skin;
	public GameObject playerPrefab;
	public static string roomId = "";
	public static string myId = "";
	public static string status = "";
	public static List<ParticipantInfo> participants = new List<ParticipantInfo>();
	private static MultiPlayerGame _instance;
	private static GameObject localPlayer = null;
	void Start () {
		_instance = this;
		GPGSUnityPlugin.StartPlay(true);
	}
	public static void Addplayer(string id){//Adds a gameobject for this player
		GameObject go =	(GameObject)GameObject.Instantiate(_instance.playerPrefab,Vector3.zero,Quaternion.identity);
		go.name = id;
		go.SendMessage("SetLabel",GetDisplayName(id));
		if(id == myId) localPlayer = go;//this is the local player gameobject that will be controlled by the mouse
	}
	public static void MovePlayer(string gameObjectName,Vector2 newPosition){
		GameObject player = GameObject.Find(gameObjectName);
		player.transform.position = new Vector3(newPosition.x,newPosition.y,player.transform.position.z);
	}
	public static string GetDisplayName(string pid){
		var player = participants.Find(p => p.participantId == pid);
		if(player != null)
			return player.displayName;
		else
			return "";
	}
	void OnGUI(){
		if (skin != null){
            GUI.skin = skin;
        }
		BeginPage(Screen.width/1.1f, Screen.height/1.01f );
		if(GUILayout.Button("Login")){
			
			GPGSUnityPlugin.BeginUserInitiatedSignIn();
		}
		if(GUILayout.Button("Quick Game")){
			GPGSUnityPlugin.StartQuickGame(1,3);
		}
		GUILayout.Label("RoomID: " + roomId);
		GUILayout.Label("MyID: " + myId);
		GUILayout.Label("Status: " + status);
		GPGSUnityPlugin.response = GUILayout.TextField(GPGSUnityPlugin.response);
		foreach(var p in participants){
			GUILayout.Label("Display Name: " + p.displayName + " Status: " +  p.statusCode);
		}
		EndPage();
	}
	void BeginPage(float width, float height){
        GUILayout.BeginArea(new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
    }
    void EndPage(){
        GUILayout.EndArea();
    }
	void Update(){
		if(Input.GetMouseButtonDown(0) && localPlayer){
		    Vector3 worldtouchpos = Camera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
			localPlayer.transform.position = new Vector3(worldtouchpos.x,worldtouchpos.y,localPlayer.transform.position.z);
			foreach(var p in participants){
				MessageFormat messageFormat = new MessageFormat(){gameObjectName=myId,moveToX=localPlayer.transform.position.x,moveToY=localPlayer.transform.position.y};
				string jsonstring = JsonMapper.ToJson(messageFormat);
				Debug.Log("SendMessage to:" + p.displayName + " Message length: " + jsonstring.Length);
				GPGSUnityPlugin.SendUnreliableRealTimeMessage(jsonstring,roomId,p.participantId);
			}
		}
	}
	void LateUpdate(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
