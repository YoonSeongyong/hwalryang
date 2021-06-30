using UnityEngine;
using System.Collections;
using LitJson;

public class GPGSUnityPlugin {
	public static string response = "";
	private static string classname = "com.platoevolved.gpgsunity.UnityAndroidInterface";
	
	public static void EnableDebugLog(bool enabledebug){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("EnableDebugLog",enabledebug);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void StartPlay(bool allclients){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("StartPlay",allclients);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void StopPlay(){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("StopPlay");			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void StartConnections(){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("StartConnections");			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
		
	}
	public static void BeginUserInitiatedSignIn(){
#if UNITY_EDITOR 
		//Note that this code here is just to emulate in the editor what basically happens on the device. 
		GameObject unitygameobjectreceiver = GameObject.Find("UnityGameObjectReceiver");
		unitygameobjectreceiver.SendMessage("OnSignInSucceeded","Sign In Successful.");
#else
		AndroidJavaClass jc = new AndroidJavaClass(classname);
		jc.CallStatic("BeginUserInitiatedSignIn");			
#endif
	}
	public static void SignOut(){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("SignOut");			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void SetSignInMessages(string signingInMessage, string signingOutMessage){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("SetSignInMessages",signingInMessage,signingOutMessage);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void UnlockAchievement(string id){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("UnlockAchievement",id);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void SubmitScore(string id,long score){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("SubmitScore",id,score);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void IncrementAchievement(string id,int numSteps){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("IncrementAchievement",id,numSteps);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void ShowAchievements(){
		try {
			Debug.Log("ShowAchievements");
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("ShowAchievements");			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void ShowLeaderboards(){
		try {
			Debug.Log("ShowLeaderboards");
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("ShowLeaderboards");		
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void ShowLeaderboard(string id){
		try {
			Debug.Log("ShowLeaderboard: " + id);
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("ShowLeaderboard",id);		
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void ShowInvitationInbox(){
		try {
			Debug.Log("ShowInvitationInbox");
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("ShowInvitationInbox");			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void ShowInvitePlayers(int minOpponents,int maxOpponents){
		try {
			Debug.Log("ShowInvitePlayers");
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("ShowInvitePlayers",minOpponents,maxOpponents);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void SaveToCloud(int stateKey, string data){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("SaveToCloud",stateKey,data);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void LoadFromCloud(int stateKey,bool resolvefromserver){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("LoadFromCloud",stateKey,resolvefromserver);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	
	public static void StartQuickGame(int minOpponents,int maxOpponents){
#if UNITY_EDITOR 
		GameObject unitygameobjectreceiver = GameObject.Find("UnityGameObjectReceiver");
		RoomInfo roominfo = new RoomInfo(){myId="me_123",roomId="room_456"};
		roominfo.participants.Add(new ParticipantInfo(){displayName="Test Name",participantId="me_123"});
		unitygameobjectreceiver.SendMessage("OnRoomCreated",JsonMapper.ToJson(roominfo));	
#else
		AndroidJavaClass jc = new AndroidJavaClass(classname);
		jc.CallStatic("StartQuickGame",minOpponents,maxOpponents);			
#endif
	}
	public static void AcceptInviteToRoom(string invId){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("AcceptInviteToRoom",invId);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void LeaveRoom(string roomId){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("LeaveRoom",roomId);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void SendReliableRealTimeMessage(string messageData,string roomId,string recipientParticipantId){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("SendReliableRealTimeMessage",messageData,roomId,recipientParticipantId);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	public static void SendUnreliableRealTimeMessage(string messageData,string roomId,string recipientParticipantId){
		try {
			AndroidJavaClass jc = new AndroidJavaClass(classname);
			jc.CallStatic("SendUnreliableRealTimeMessage",messageData,roomId,recipientParticipantId);			
		} catch (System.Exception ex) {
			Debug.Log("Note, you must be deployed to an Android device! " + ex.Message);
		}
	}
	
	
	
}
