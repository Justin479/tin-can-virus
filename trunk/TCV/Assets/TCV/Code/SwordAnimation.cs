using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour {
	
	bool rotating = false;
	Quaternion rot;
	float initialAngle;
	float raiseSpeed = 65;
	float swingAngle = 45;
	
	// Use this for initialization
	void Start () {
		rot = transform.rotation;
		initialAngle = transform.localEulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Swing Forward
		if (Input.GetMouseButtonDown(0))
		{
			transform.localEulerAngles = new Vector3(43,0,0);
			transform.Rotate( new Vector3(swingAngle,0,0), Space.Self);
			rotating = true;
		}
		else
		{
			if (rotating)
			{
				transform.Rotate( new Vector3(-Time.deltaTime * raiseSpeed,0,0), Space.Self);	
				if (  transform.localEulerAngles.x < initialAngle)
				{
					transform.localEulerAngles = new Vector3(initialAngle,0,0);
						rotating = false;
				}
			}
		}
		
		
	}
}
