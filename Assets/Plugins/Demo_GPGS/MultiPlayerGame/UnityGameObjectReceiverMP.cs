using UnityEngine;
using System.Collections;
using LitJson;

public class UnityGameObjectReceiverMP : MonoBehaviour {
	public void OnSignInSucceeded(string response){
		GPGSUnityPlugin.response = response;
	}
	public void OnSignInFailed(string response){
		GPGSUnityPlugin.response = response;
		MultiPlayerGame.status = "Sign In Failed!";
	}
	public void OnRoomCreated(string response){
		GPGSUnityPlugin.response = response;
		RoomInfo roominfo = JsonMapper.ToObject<RoomInfo>(response);
		MultiPlayerGame.roomId = roominfo.roomId;
		MultiPlayerGame.myId = roominfo.myId;
		MultiPlayerGame.status = "Room Created.";
		MultiPlayerGame.participants = roominfo.participants;
		MultiPlayerGame.Addplayer(roominfo.myId);
	}
	public void OnConnectedToRoom(string response){
		GPGSUnityPlugin.response = response;
		RoomInfo roominfo = JsonMapper.ToObject<RoomInfo>(response);
		MultiPlayerGame.roomId = roominfo.roomId;
		MultiPlayerGame.myId = roominfo.myId;
		MultiPlayerGame.status = "Connected to Room.";
		MultiPlayerGame.participants = roominfo.participants;
	}
	public void OnRealTimeMessageReceived(string response){
		GPGSUnityPlugin.response = response;
		RTMInfo rtmInfo  = JsonMapper.ToObject<RTMInfo>(response);
		MessageFormat messageFormat = JsonMapper.ToObject<MessageFormat>(rtmInfo.messageData);
		MultiPlayerGame.MovePlayer(messageFormat.gameObjectName,new Vector2((float)messageFormat.moveToX,(float)messageFormat.moveToY));
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
		RoomInfo roominfo = JsonMapper.ToObject<RoomInfo>(response);
		MultiPlayerGame.roomId = roominfo.roomId;
		MultiPlayerGame.myId = roominfo.myId;
		MultiPlayerGame.status = "Peer Connected.";
		MultiPlayerGame.participants = roominfo.participants;
		foreach(var pid in roominfo.participantIds){
			MultiPlayerGame.Addplayer(pid);
		}
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
