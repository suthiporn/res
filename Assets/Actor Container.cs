using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot("SaveCollection")]
public class ActorContainer 
{
	[XmlArray("Actors")]
	[XmlArrayItem("Actor")]
	public List<ActorData> actors = new List<ActorData>();
}
