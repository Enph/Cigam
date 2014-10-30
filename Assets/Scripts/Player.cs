using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	public float speed = 10f;
	public GameObject camera;
	private Vector3 SpawnPosition;
	public Transform creation;


	void start()
	{
		//camera = (GameObject) GameObject.FindWithTag("MainCamera");
	}
	
	public void spawnPlayer(string playerCamera)
	{
		this.camera = GameObject.Find(playerCamera);
	}

	void Update()
	{
		if (photonView.isMine)
			InputMovement();
	}
	
	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
			stream.SendNext(rigidbody.position);
		else
			rigidbody.position = (Vector3)stream.ReceiveNext();
	}
}
