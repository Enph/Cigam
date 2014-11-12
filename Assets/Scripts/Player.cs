using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	string playerName;
	int teamId;

	public float player_Xcoord, player_Ycoord, player_Zcoord;

	void start()
	{
		//int teamId = 0;
		this.playerName = "Default_Player# "+Random.Range(0,10);
	}


	void Update()
	{
		/*
		if (photonView.isMine)
		{
			//do stuff only i can do
		}
		*/
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
