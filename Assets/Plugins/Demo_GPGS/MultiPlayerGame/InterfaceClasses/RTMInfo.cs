using UnityEngine;
using System.Collections;

public class RTMInfo{//RealTimeMessage info used in OnRealTimeMessageReceived 
	public int describeContents;
	public bool isReliable;
	public string senderParticipantId;
	public string messageData;
}
