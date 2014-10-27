using UnityEngine;
using System.Collections;

public class DeckBuilder : MonoBehaviour {

	public bool toggleLand;
	public bool toggleCreatures;
	public bool toggleSorceries;
	public bool toggleInstantCasts;

	// Use this for initialization
	void Start () {
		this.toggleLand = false;
		this.toggleCreatures = false;
		this.toggleSorceries = false;
		this.toggleInstantCasts = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box (new Rect (0, 0,Screen.width,Screen.height), "Build a Deck"); //a box to hold all the buttons


		//Placeholder for cards to be displayed. Format cards between the BeginArea and EndArea
		GUI.Box (new Rect (Screen.width * 0.05f,Screen.height * 0.10f,Screen.width * 0.65f,Screen.height * 0.50f), "Placeholder for cards"); //a box window which will host all the cards to be displayed
		GUILayout.BeginArea (new Rect (Screen.width * 0.05f,Screen.height * 0.10f,Screen.width * 0.65f,Screen.height * 0.50f));
		GUILayout.EndArea();

		//Placeholder for the player's picked cards
		GUI.Box (new Rect (Screen.width * 0.80f,Screen.height * 0.10f,Screen.width * 0.15f,Screen.height * 0.60f), "PlayerName Deck"); //a box window to display all the cards a player has picked
		GUILayout.BeginArea (new Rect (Screen.width * 0.80f,Screen.height * 0.10f,Screen.width * 0.15f,Screen.height * 0.60f));
		GUILayout.EndArea();
		
		
		GUI.Box (new Rect (Screen.width * 0.30f,Screen.height * 0.65f,Screen.width * 0.40f,Screen.height * 0.20f), "Filter by:"); //Filter cards window section
		GUILayout.BeginArea (new Rect (Screen.width * 0.30f,Screen.height * 0.65f,Screen.width * 0.40f,Screen.height * 0.20f));
			toggleLand = GUILayout.Toggle(toggleLand, "Land");
			toggleCreatures = GUILayout.Toggle(toggleCreatures, "Creatures");
			toggleSorceries = GUILayout.Toggle(toggleSorceries, "Sorceries");
			toggleInstantCasts = GUILayout.Toggle(toggleInstantCasts, "Instants");
		GUILayout.EndArea ();
		
		

		
		if(GUI.Button (new Rect (Screen.width * 0.80f,Screen.height * 0.80f,Screen.width * 0.10f,Screen.height * 0.10f), "Save Deck"))
		{

		}
		else if (GUI.Button (new Rect (Screen.width * 0.05f,Screen.height * 0.80f,Screen.width * 0.10f,Screen.height * 0.10f), "Back")) 
		{
			//back to main menu
			Application.LoadLevel("GameLobby");
		}
		else
		{

		}

	}
}
