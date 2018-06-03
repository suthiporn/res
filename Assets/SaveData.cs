using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class SaveData : MonoBehaviour 
{
	public static ActorContainer actorContainer = new ActorContainer ();

	public delegate void SerializeAction ();
	public static event SerializeAction OnLoaded;
	public static event SerializeAction OnBeforeSave;
	public static float healts = 10;

	public static void Load (string path)
	{
		actorContainer = LoadActors (path);

		foreach (ActorData data in actorContainer.actors)
		{
			GameController.CreateActor (data, GameController.playerPath,
				new Vector3(data.posX, data.posY, data.posZ), Quaternion.identity);
		}
	
		OnLoaded ();
	}

	public static void Save (string path, ActorContainer actors)
	{
		OnBeforeSave ();

		SaveActors (path, actors);

		ClearActors ();
	}

	public static void AddActorData (ActorData data)
	{
		actorContainer.actors.Add (data);
	}

	public static void ClearActors ()
	{
		actorContainer.actors.Clear ();
	}

	#region Pattern Load File XML
	private static  ActorContainer LoadActors (string path)
	{
		XmlSerializer serializer = new XmlSerializer (typeof(ActorContainer));

		FileStream stream = new FileStream (path, FileMode.Open);

		ActorContainer actors = serializer.Deserialize (stream) as ActorContainer;

		stream.Close ();

		return actors;
	}
	#endregion

	#region Pattern Save Down File XML	
	private static void  SaveActors (string path, ActorContainer actors)
	{
		XmlSerializer serializer = new XmlSerializer (typeof(ActorContainer));

		FileStream stream = new FileStream (path, FileMode.Create);

		serializer.Serialize (stream, actors);

		stream.Close ();
	}
	#endregion
}
