using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {

    //Zoom Variables
    float normalView = 60;
    float zoomView = 20;
    public Camera cam;
    public MouseLook viewY;     //Script in Player Camera object, used for adjusting mouse sensitivity.
    public MouseLook viewX;     //Script in Player object

	// Use this for initialization
	void Start () {
	
	}
	
	//In the update function, we will eventually have a switch statement that detects wich
    //weapon the player has equipped and chooses the appropriate altFunction. Right now,
    //Zoom is all we got.
	void Update () {
        Zoom();
	}

    public void Zoom()
    {
        if (Input.GetMouseButton(1))    //Zoom
        {
            if (cam.fov > zoomView)
                cam.fov -= 5;
            viewY.sensitivityY = 1; //These values are stored in two different scripts, for reasons I have no control over :(
            viewX.sensitivityX = 1;
        }
        else if (cam.fov < normalView)  //Reset View
        {
            cam.fov += 5;
            if (cam.fov > normalView) cam.fov = normalView;
            viewY.sensitivityY = 10;
            viewX.sensitivityX = 15;
        }
    }
}
