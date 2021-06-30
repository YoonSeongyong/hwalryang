using UnityEngine;
using System.Collections;
using System;
using LitJson;

public class SimpleDemo : MonoBehaviour {
	public GUISkin skin;
	private string achievementid="CgkIxtOZvIkHEAIQBw";
	private string leaderboardid = "CgkIxtOZvIkHEAIQBg";
	private string score = "900";
	private string data="";
	private string roomId="";
	private string participantId="";
	
	void Awake(){
		GPGSUnityPlugin.EnableDebugLog(true);
		GPGSUnityPlugin.StartPlay(true);
	}
	
	void Start(){
		GPGSUnityPlugin.StartConnections();//Try to silently log in.
	}
	
	void OnGUI(){
		if (skin != null){
            GUI.skin = skin;
        }
		BeginPage(Screen.width/1.1f, Screen.height/1.01f );
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Login")){
			GPGSUnityPlugin.BeginUserInitiatedSignIn();
		}
		if(GUILayout.Button("Logout")){
			GPGSUnityPlugin.SignOut();
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("UnlockAchievement")){
			GPGSUnityPlugin.UnlockAchievement(achievementid);
		}
		achievementid = GUILayout.TextField(achievementid);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("SubmitScore")){
			try {
				long longscore = Convert.ToInt64(score);
				GPGSUnityPlugin.SubmitScore(leaderboardid,longscore);
			} catch {
				Debug.Log("Score must be an integer");				
			}
		}
		if(GUILayout.Button("Show")){
			GPGSUnityPlugin.ShowLeaderboard(leaderboardid);
		}
		GUILayout.Label("ID: ");
		leaderboardid = GUILayout.TextField(leaderboardid);
		GUILayout.Label("Score: ");
		score = GUILayout.TextField(score);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("ShowAchievements")){
			GPGSUnityPlugin.ShowAchievements();
		}
		if(GUILayout.Button("ShowLeaderboards")){
			GPGSUnityPlugin.ShowLeaderboards();
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("ShowInvitationInbox")){
			GPGSUnityPlugin.ShowInvitationInbox();
		}
		if(GUILayout.Button("ShowInvitePlayers")){
			GPGSUnityPlugin.ShowInvitePlayers(1,3);
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("SaveToCloud")){
			GPGSUnityPlugin.SaveToCloud(0,data);
		}
		if(GUILayout.Button("LoadFromCloud")){
			GPGSUnityPlugin.LoadFromCloud(0,true);
		}
		GUILayout.EndHorizontal();
		data = GUILayout.TextField(data);
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("StartQuickGame")){
			GPGSUnityPlugin.StartQuickGame(1,1);
		}
		if(GUILayout.Button("LeaveRoom")){
			GPGSUnityPlugin.LeaveRoom(roomId);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("RoomID: " + roomId);
		GUILayout.Label("ParticipantID: " + participantId);
		try {
			JsonData jdata = JsonMapper.ToObject(GPGSUnityPlugin.response);
			roomId = (string)jdata["roomId"];
			participantId = (string)jdata["participantIds"][0];
		} catch {
		}
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("SendReliableRTM")){
			GPGSUnityPlugin.SendReliableRealTimeMessage(data,roomId,participantId);
		}
		if(GUILayout.Button("SendUnreliableRTM")){
			GPGSUnityPlugin.SendUnreliableRealTimeMessage(data,roomId,participantId);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("Response: ");
		GPGSUnityPlugin.response = GUILayout.TextField(GPGSUnityPlugin.response);
		EndPage();
	}
	void BeginPage(float width, float height){
        GUILayout.BeginArea(new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
    }
    void EndPage(){
        GUILayout.EndArea();
    }
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			GPGSUnityPlugin.StopPlay();
			Application.Quit();
		}
	}
}
