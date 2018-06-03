using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSave : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		AutoSave.Load ();

		AutoSave.Save ();

		Debug.Log (GameData.playerName);
		Debug.Log (GameData.playerLevel);
		Debug.Log (GameData.sence);
	}
}
