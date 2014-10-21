using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	private const string ServerGameName = "Enph_UniqueGameName#76842"; //This name has to be unique for the unity master server. Also needs to be changed to playername_game1 later
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f; //Max refresh rate when pinging unity master server to retrive the game list
	HostData[] hostData; //datastorage to hold all serverlist with ServerGameName 
	
	private void StartServer()
	{
		Network.InitializeServer(2,25002,false); //Num of players, port, nattype
		MasterServer.RegisterHost(ServerGameName,"Player1_Game1","Description. trying to get this to work!"); //Player1_Game1 needs to be a variable later
	}
	
	void OnServerInitialize()
	{
		Debug.Log("Server Initialized");
	}
	
	void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		if( masterServerEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("Registration Successful");
	}
	
	public IEnumerator RefreshServerList()
	{
		Debug.Log ("Refreshing Server List...");
		MasterServer.RequestHostList(ServerGameName);
		float timeStart = Time.time;
		float timeEnd = timeStart + refreshRequestLength;
		
		while(Time.time < timeEnd)
		{
			hostData = MasterServer.PollHostList();
			yield return new WaitForEndOfFrame(); //pause
		}
		
		if(hostData == null || hostData.Length == 0)
		{
			Debug.Log ("No Servers have been found");
		}
		else
		{
			Debug.Log ("Number of Servers Found: " + hostData.Length);
		}	
	}
	
	public void OnGUI()
	{
		if(Network.isClient || Network.isServer) //Clear the screen
			return;
		
		if(GUI.Button(new Rect(100,100,250,100), "Start Server"))
		{
			//START SERVER
			StartServer();
		}
		
		if(GUI.Button (new Rect(100,250,250,100), "Refresh Hosts"))
		{
			//REFRESH SERVER LIST
			StartCoroutine("RefreshServerList");
		}
		
		if(hostData != null)
		{
			for(int i =0;i<hostData.Length;i++)
			{
				if(GUI.Button(new Rect(Screen.width / 2,65f + (30f * i),300f,30f),hostData[i].gameName))
				{
					Network.Connect(hostData[i]);
				}
			}
		}
	}
}

