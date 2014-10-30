using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public string currentMenu;

	
	// Use this for initialization
	void Start () {
		this.currentMenu = "MainMenuGUI";	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI()
	{
		if(this.currentMenu == "MainMenuGUI")
		{
			MainMenuGUI();
		}
		else if(this.currentMenu == "OptionsGUI")
		{
			OptionsGUI();
		}
		else if(this.currentMenu == "GameLobbyGUI")
		{
			Application.LoadLevel("GameLobby");
		}
		else
		{
			Debug.Log("Error Loading GUI View");
		}
	}

	public void MainMenuGUI()
	{
		//create a menu
		GUI.Box (new Rect (0, 0,Screen.width,Screen.height), "CIGAM"); //a box to hold all the buttons
		
		if (GUI.Button (new Rect (Screen.width / 8, Screen.height / 8 + 10, 3 * Screen.width / 4, Screen.height / 8), "Start Game"))
		{
			//Application.LoadLevel(); //open the game scene. NEEDS PARAMETER OF THE SCENE NAME
			this.currentMenu = "GameLobbyGUI";
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

	public void OptionsGUI()
	{
		GUI.Box (new Rect (0, 0,Screen.width,Screen.height), "Options"); //a box to hold all the buttons
		
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
			this.currentMenu = "MainMenuGUI";
			Debug.Log("Switching Menu to: "+currentMenu);	
		}
	}
	public void MainMenu()
	{
		//JOIN A SELECTED GAME
		if (GUI.Button (new Rect (10,50,200,50), "Join Game")) 
		{
			Debug.Log("Joining game...");

		}
		//REFRESH SERVER LIST
		else if (GUI.Button (new Rect (10,100,200,50), "Refresh List")) 
		{
			//Refresh the room list
			//StartCoroutine(networkManager.RefreshServerList());
		}

		else if (GUI.Button (new Rect (10,150,200,50), "Deck Builder")) 
		{
			//Deck Builder page
			Debug.Log ("Loading Deck Builder scene...");
		}

		else if (GUI.Button (new Rect (10,200,200,50), "Back")) 
		{
			//back to main menu
			this.currentMenu = "MainMenuGUI";
		}
		else
		{
			//Debug.Log ("GameLobbyGUI did not load anything");
		}
	}
}
