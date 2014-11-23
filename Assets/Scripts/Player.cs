using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	string playerName;
	int playerHealth;
	int opponentsHealth;
	int cardsInHand;
	int cardsInDeck;
	int teamId;
	
	void start()
	{
		//int teamId = 0;
		this.playerName = "Default_Player# "+Random.Range(0,10);
		this.playerHealth = 20;
		this.opponentsHealth = 20;

	}

	void Update()
	{

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
}
