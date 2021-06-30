using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class MessageFormat {
	public string gameObjectName;
	public double moveToX;//LitJson doesn't like floats!?
	public double moveToY;
	
}
