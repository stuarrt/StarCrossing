using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public static Transform camera;
	public static Transform player;

	public bool isMoving;

	public float lookAtDistance;

	public int cycleSpeed;
	public int cycleTrack; 
	public float speed;

	public NPCDirection? currentDirection;

	public enum NPCDirection
	{
		Left, 
		Right,
		Forward,
		Backward, 
		Stop,
		Looking,
	}
	// Use this for initialization
	void Start () {

		camera = MainCamera.Instance.transform;
		player = PlayerController.MyTransform;

		if (lookAtDistance == 0){
			lookAtDistance = 1;
		}

		if (cycleSpeed == 0){
			cycleSpeed = 125;
		}

		if (speed == 0){
			speed = 0.01f;
		}

		isMoving = true;
		cycleTrack = Random.Range (cycleSpeed - 22, cycleSpeed + 31);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Vector3.Distance(this.transform.position, player.position) < lookAtDistance){
			this.transform.LookAt(camera);
			StopMoving(NPCDirection.Looking);
			return;
		}
		else if (currentDirection == NPCDirection.Looking){
			this.transform.rotation = Quaternion.identity;
			isMoving = true;
			ChooseDirection(Random.Range(0, 5));
		}

		else if ((cycleTrack <= 0) && (isMoving)){
			StopMoving();
		}
		else if ((cycleTrack <= 0) && (!isMoving)){
			ChooseDirection(Random.Range(0, 5));
			isMoving = true;
		}

		if (isMoving){
			switch(currentDirection){		
			case NPCDirection.Left:
				transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
				break;

			case NPCDirection.Right:
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
				break;

			case NPCDirection.Forward:
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed);
				break;

			case NPCDirection.Backward:
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
				break;
			}
		}

		cycleTrack--;
	}

	void ChooseDirection(int i){
		currentDirection = (NPCDirection) i;
		cycleTrack = Random.Range (cycleSpeed - 20, cycleSpeed + 27);
	}

	void StopMoving(NPCDirection newDirection = NPCDirection.Stop){
		currentDirection = newDirection;

		isMoving= false;
		cycleTrack = Random.Range (cycleSpeed - 25, cycleSpeed + 30);
	}

}
