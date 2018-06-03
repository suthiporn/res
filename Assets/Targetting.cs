using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Targetting : MonoBehaviour 
{
	public List<Transform> targets;
	private Transform selectedTarget;

	private Transform myTransform;

	void Start ()
	{
		targets = new List<Transform> ();
		selectedTarget = null;
		myTransform = transform;

		AddAllEnemies ();
	}

	public void AddAllEnemies ()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemies");

		foreach (GameObject enemy in go)
			AddTarget (enemy.transform);
	}

	public void AddTarget(Transform enemy)
	{
		targets.Add (enemy);
	}

	private void SortTargetsByDistance ()
	{
		targets.Sort(delegate(Transform t1, Transform t2) 
		{
				return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));	
				});
	}
		
	#region เลือกมอนเตอร์
	private void TargetEnemy ()
	{
		if (selectedTarget == null)
		{
			SortTargetsByDistance ();
			selectedTarget = targets [0];
		}
		else 
		{
			int index = targets.IndexOf (selectedTarget);

			if (index < targets.Count - 1)
			{
				index++;
			}
			else 
			{
				index = 0;
			}
			DeselectTarget ();
			selectedTarget = targets [index];
		}
		SelectTarget ();
	}
	#endregion

	#region ทำสีที่ตัวมอนที่เลือก
	private void SelectTarget()
	{
		selectedTarget.GetComponent<Renderer> ().material.color = Color.red;
	}
	#endregion

	private void DeselectTarget ()
	{
		selectedTarget.GetComponent<Renderer> ().material.color = Color.blue;
		selectedTarget = null;
	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			TargetEnemy ();
		}
	}
}
