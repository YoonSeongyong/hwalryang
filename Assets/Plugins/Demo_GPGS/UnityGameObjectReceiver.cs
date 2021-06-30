using UnityEngine;
using System.Collections;

public class UnityGameObjectReceiver : MonoBehaviour {
	
	public void OnSignInSucceeded(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnSignInFailed(string response){
		GPGSUnityPlugin.response = response;
	}
	//Cloud callbacks
	public void OnStateConflict(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnStateLoaded(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnStateLoadedError(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnError(string response){
		GPGSUnityPlugin.response = response;
	}
	
	public void OnJoinedRoom(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnLeftRoom(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnRoomConnected(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnRoomCreated(string response){
		GPGSUnityPlugin.response = response;
	}
	
	public void OnInvitationReceived(string response){
		GPGSUnityPlugin.response = response;
	}
	
	public void OnRealTimeMessageReceived(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnConnectedToRoom(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnDisconnectedFromRoom(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnPeerDeclined(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnPeerInvitedToRoom(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnPeerJoined(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnPeerLeft(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnPeersConnected(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnPeersDisconnected(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnRoomAutoMatching(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnRoomConnecting(string response){
		GPGSUnityPlugin.response = response;
	}
	

}
