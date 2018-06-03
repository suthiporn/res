using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour {

	public float a;
	public Image imageCooldown1;
	public Image imageCooldown2;
	[SerializeField]

	public static float cooldown1 = 5f; 
	public static float cooldown2 = 5f;

	public static bool Cooldown1;
	public static bool Cooldown2;

	public bool isCooldown1;
	bool isCooldown2;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1) && Cooldown2 == false)
		{
			isCooldown1 = true;
		}

		if (isCooldown1)
		{
			imageCooldown1.fillAmount += 1 / cooldown1 * Time.deltaTime;
			if (imageCooldown1.fillAmount < 5 && imageCooldown1.fillAmount > 0)
			{
				Cooldown1 = true;
			}
			if (imageCooldown1.fillAmount >= 1)
			{
				imageCooldown1.fillAmount = 0;
				isCooldown1 = false;
			}
			if (imageCooldown1.fillAmount <= 0)
			{
				Cooldown1 = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && Cooldown1 == false)
		{
			isCooldown2 = true;
		}

		if (isCooldown2)
		{
			imageCooldown2.fillAmount += 1 / cooldown1 * Time.deltaTime;
			if (imageCooldown2.fillAmount < 5 && imageCooldown2.fillAmount > 0)
			{
				Cooldown2 = true;
			}
			if (imageCooldown2.fillAmount >= 1)
			{
				imageCooldown2.fillAmount = 0;
				isCooldown2 = false;
			}
			if (imageCooldown2.fillAmount <= 0)
			{
				Cooldown2 = false;
			}
		}
	}
}
