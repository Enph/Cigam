using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public string currentMenu;
	// Use this for initialization
	void Start () {
		this.currentMenu = "Options";

	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void OptionsGUI () 
	{
		
		GUI.Box (new Rect (Screen.width / 8, 10, 3 * Screen.width / 4, 3 * Screen.height / 4), "Options"); //a box to hold all the buttons
		
		if (GUI.Button (new Rect (Screen.width / 4, 3 * Screen.height / 8 + 40, 3 * Screen.width / 20, Screen.height / 8), "Apply Settings"))
		{
			//Apply Current Settings
		}
		
		if (GUI.Button (new Rect (Screen.width / 2, 3 * Screen.height / 8 + 40, 3 * Screen.width / 15, Screen.height / 8), "Default Settings")) 
		{
			//Set back to default settings *Needs to be done*
			Debug.Log("Settings Saved");
		}
		
		if (GUI.Button (new Rect (Screen.width / 4 , 2 * Screen.height / 8 + 40, 3 * Screen.width / 20, Screen.height / 8), "Back")) 
		{

			this.currentMenu = "MainMenu";
			//Debug.Log("Switching Menu to: "+currentMenu);

		}


	}

	public string getCurrentMenu()
	{
		return currentMenu;
	}
	
}
