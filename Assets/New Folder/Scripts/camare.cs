using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camare : MonoBehaviour 
{

	protected Transform camares;
	protected Transform target;

	protected Vector3 LocalRotation;
	protected float camareDistance = 10f;

	public float MouseSensitivity = 4f;
	public float ScrollSensitivity = 2f;
	public float OrbitDampening = 10f;
	public float ScrollDampening = 6f;

	public bool camareDisabled = false;

	void Start () 
	{
		this.camares = this.transform;
		this.target = this.transform.parent;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift))
			camareDisabled = !camareDisabled;


			if (!camareDisabled) {
				if (Input.GetAxis ("Mouse ScrollWheel") != 0f) 
				{
					float ScrollAmount = Input.GetAxis ("Mouse ScrollWheel") * ScrollSensitivity;

					ScrollAmount *= (this.camareDistance * 0.3f);

					this.camareDistance += ScrollAmount * -1f;

					this.camareDistance = Mathf.Clamp (this.camareDistance, 1.5f, 100f);
				}

				if (Input.GetMouseButton (1)) 
				{
					if (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0) 
					{

						LocalRotation.x += Input.GetAxis ("Mouse X") * MouseSensitivity;
						LocalRotation.y -= Input.GetAxis ("Mouse Y") * MouseSensitivity;

						LocalRotation.y = Mathf.Clamp (LocalRotation.y, 0, 90f);
					}

			
				Quaternion QT = Quaternion.Euler (LocalRotation.y, LocalRotation.x, 0);
				this.target.rotation = Quaternion.Lerp (this.target.rotation, QT, Time.deltaTime * OrbitDampening);

				if (this.camares.localPosition.z != this.camareDistance * -1f) {
					this.camares.localPosition = new Vector3 (0f, 0f, Mathf.Lerp (this.camares.localPosition.z, this.camareDistance * -1f, Time.deltaTime * ScrollDampening));
				}
			}
		}
	}
}