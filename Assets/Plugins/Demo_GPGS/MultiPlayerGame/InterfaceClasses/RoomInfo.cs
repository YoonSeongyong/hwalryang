using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomInfo  {
	public int statusCode;
	public string roomId;
	public string myId;
	public List<string> participantIds;//list of changes, onpeerleft will be peerswholeft
	public List<ParticipantInfo> participants = new List<ParticipantInfo>();
}
