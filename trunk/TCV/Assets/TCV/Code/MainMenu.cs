using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	bool showCredits = false;
	Rect creditsPosition;
	public string levelName;
	
	// Use this for initialization
	void Start () {
		creditsPosition = new Rect(148,84,128,256);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() 
	{
		if (GUI.Button(new Rect(10, 10, 128, 64), "Start Game"))
		{
			Application.LoadLevel(levelName);
		}
		
		if (GUI.Button(new Rect(10, 84, 128, 64), "Credits"))
		{
			showCredits = !showCredits;
		}
		
		if (GUI.Button(new Rect(10, 158, 128, 64), "Quit"))
		{
			//do stuff...	
		}
		
		if (showCredits)
		{
			GUI.Label(creditsPosition,"Contributors:\n Anna\n Alex\n James\n John\n David\n Aaron");	
		}
	}
}
