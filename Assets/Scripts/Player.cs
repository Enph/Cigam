using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	string playerName;
	int teamId;

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

	public void setPlayerName(string name)
	{
		this.playerName = name;
	}
}
