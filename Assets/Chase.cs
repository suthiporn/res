using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public Transform player;
	static Animator anim;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	float rotSpeed = 0.2f;
	float speed = 1.5f;
	float accurayWP = 5.0f;
	public float reachDist=1.0f;
	private float distance;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		float angle = Vector3.Angle (direction, this.transform.forward);

		if (state == "patrol" && waypoints.Length > 0) {
			anim.SetBool ("_isIdle", false);
			anim.SetBool ("_isWalking", true);
			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accurayWP) {
				currentWP++;
				if (currentWP >= waypoints.Length) {
					currentWP = 0;
				}
			}

			// rotate towards waypoint
			direction = waypoints [currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}
		if (Vector3.Distance (player.position, this.transform.position) < 10 && (angle < 180 || state == "pursuing")) {
			state = "pursuing";
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			if (direction.magnitude > 2) {
				this.transform.Translate (0, 0, Time.deltaTime * (speed + 1.2f));
				anim.SetBool ("_isWalking", true);
				anim.SetBool ("_isAttack", false);
			} else {
				anim.SetBool ("_isAttack", true);
				anim.SetBool ("_isWalking", false);
			}
		} else {
			anim.SetBool ("_isWalking", true);
			anim.SetBool ("_isAttack", false);
			state = "patrol";
		}
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
		if (waypoints.Length > 0)
		{
			for (int i = 0; i < waypoints.Length; i++) {
				if (waypoints [i] != null) {
					Gizmos.DrawWireSphere (waypoints [i].transform.position, reachDist);
				}

				if (i > 0) {
					Gizmos.DrawLine (waypoints [i - 1].transform.position, waypoints [i].transform.position);
					distance += Vector3.Distance (waypoints [i - 1].transform.position, waypoints [i].transform.position);
				}
			}
		}
	}
}

			
