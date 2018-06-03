using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbbbb : MonoBehaviour {

	float aaaa;
	float aaa;
	// Use this for initialization
	void Start () 
	{
		aaaa = Time.fixedDeltaTime;
		aaa = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (aaaa);
		Debug.Log (aaa);
	}
}
