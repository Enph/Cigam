using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	public GameManager[] gameManager;


	string playerName;
	int playerHealth;
	int opponentsHealth;
	int teamId;
	public Texture[] currentZoom;
	public Land_Island[] myIsland;

	public string[] playerDeck;
	public Texture[] MyHandOfCardsTexture;

	
	void start()
	{
		this.playerName = "Default_Player# "+Random.Range(0,10);
		this.playerHealth = 20;
		this.opponentsHealth = 20;

		gameManager = GameObject.FindObjectsOfType<GameManager>();
		playerDeck = gameManager[0].deck_Red_White; //get randomly generated deck of 60 cards
		DealInitialHand(); //Deal the player 7 cards

	}

	void Update()
	{
		myIsland = GameObject.FindObjectsOfType<Land_Island>();
		currentZoom = new Texture[myIsland.Length];
		for(int i = 0; i < myIsland.Length; i++){
			currentZoom[i] = myIsland[i].currentText;
		}
	}

	void OnPhotonSerialView(PhotonStream stream , PhotonMessageInfo info)
	{
		if(stream.isWriting)
		{
			//This is our player stuff
			stream.SendNext(playerHealth);
		}
		else
		{
			//this is player 2 stuff
			this.opponentsHealth = (int) stream.ReceiveNext();
		}
	}


	public string getPlayerName()
	{
		return this.playerName;
	}

	public void setPlayerName(string name)
	{
		this.playerName = name;
	}

	void OnGUI(){
		DisplayZoomCard ();
	}

	void DisplayZoomCard(){
		for(int i = 0; i < currentZoom.Length; i++){
			if(currentZoom[i] != null){
				GUI.Box (new Rect(Screen.width * 0.74f, Screen.height * 0.6f, Screen.width / 4f, Screen.height / 3f), currentZoom[i]);
			}
		}
	}

	void DealInitialHand()
	{
		MyHandOfCardsTexture = new Texture[7];


/*		for(int i=0;i<MyHandOfCardsTexture;i++)
		{
			//MyHandOfCardsTexture[i] = 
			GUI.Box (new Rect(Screen.width * 0.74f, Screen.height * 0.2f + (i+100), Screen.width / 4f, Screen.height / 3f), MyHandOfCardsTexture[i]);

		}*/
	}
}
