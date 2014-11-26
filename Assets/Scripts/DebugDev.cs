using UnityEngine;
using System.Collections;

public class DebugDev : Photon.MonoBehaviour {
	
	
	public NetworkManager[] networkManager;
	public VectorManager[] vectorManager;
	public GameManager[] gameManager;
	public Player[] player;
	
	public bool showDebugMenu = false;
	
	// Use this for initialization
	void Start () {
		

	
	}
	
	// Update is called once per frame
	void Update () {

		networkManager = GameObject.FindObjectsOfType<NetworkManager>();
		vectorManager = GameObject.FindObjectsOfType<VectorManager>();
		gameManager = GameObject.FindObjectsOfType<GameManager>();
		player = GameObject.FindObjectsOfType<Player>();


	}
	
	void OnGUI()
	{
		
		if(showDebugMenu == true)
		{
			
			if (GUI.Button (new Rect (10,300,200,50), "reduce HP")) 
			{


				PhotonView pv = player[0].GetComponent<PhotonView>();
				if(pv == null)
					Debug.Log("Take Damage pv error");
				else
					player[0].GetComponent<PhotonView>().RPC("TakeDamage",PhotonTargets.All,1 );


				Debug.Log (player[0].teamId);
				Debug.Log (player[1].teamId);

			}

			if (GUI.Button (new Rect (10,350,200,50), "reduce HP Op")) 
			{
				PhotonView pv = player[1].GetComponent<PhotonView>();
				if(pv == null)
					Debug.Log("Take Damage pv error OP");
				else
					player[0].GetComponent<PhotonView>().RPC("TakeDamage",PhotonTargets.All, 1);
				//Debug.Log (player[0].playerHealth);
			}
		}
	}
	
}
