using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour {

	public int EnemyHealth = 100;

	void DeductPoints (int DamageAmount)
	{
		EnemyHealth -= DamageAmount;
	}
	void Update () 
	{
		if (EnemyHealth <= 0)
		{
			Destroy (gameObject);
		}
	}
}
