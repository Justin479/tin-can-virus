using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour {
	
	public Animation ani;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	
		//Swing Forward
		if (Input.GetMouseButtonDown(0))
		{
			ani.Rewind();
            ani.Play();
		}
	}
}
