using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	public Player player;
	public float speed = 10f;
	public Vector3 SpawnPosition;
	public Transform creation;
	public string playerName;


	void start()
	{
		this.player = new Player();
		//camera = (GameObject) GameObject.FindWithTag("MainCamera");
		this.SpawnPosition.x = 0;
		this.SpawnPosition.y = 0;
		this.SpawnPosition.z = 0;
	}

	public void SetPosition(float x, float y, float z)
	{
		this.SpawnPosition.x = x;
		this.SpawnPosition.y = y;
		this.SpawnPosition.z = z;
	}

	public void SetCameraPosition()
	{

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
