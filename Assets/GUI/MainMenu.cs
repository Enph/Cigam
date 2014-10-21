using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	//public GUISkin MainMenuSkin;   //custom GUIskin reference
	public string currentMenu;
	private float fontSize = 27; //preferred fontsize for this screen size
	private int value = 20;  //factor value for changing fontsize if needed

	// Use this for initialization
	void Start () 
	{
		this.currentMenu = "MainMenuGUI";
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void MainMenuGUI()
	{
		//create a menu
		GUI.Box (new Rect (Screen.width, 0,Screen.width,Screen.height), "CIGAM"); //a box to hold all the buttons
		
		if (GUI.Button (new Rect (Screen.width / 8, Screen.height / 8 + 10, 3 * Screen.width / 4, Screen.height / 8), "Start Game"))
		{
			//Application.LoadLevel(); //open the game scene. NEEDS PARAMETER OF THE SCENE NAME
		}
		
		if (GUI.Button (new Rect (Screen.width / 8, 2 * Screen.height / 8 + 40, 3 * Screen.width / 4, Screen.height / 8), "Options")) 
		{
			this.currentMenu = "OptionsGUI";
			Debug.Log("Switching Menu to: "+currentMenu);
		}
		
		if (GUI.Button (new Rect (Screen.width / 8, 3 * Screen.height / 8 + 80, 3 * Screen.width / 4, Screen.height / 8), "Quit Game")) 
		{
			Debug.Log ("Exiting the Game");				
			Application.Quit (); // exit the game
		}
	}

	public string getCurrentMenu()
	{
		return currentMenu;
	}
}
