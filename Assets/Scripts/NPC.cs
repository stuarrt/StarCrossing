using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC : MonoBehaviour {

	public static Transform camera;
	public static Transform player;

	public bool isMoving;
	public bool isStealthy;

	public float lookAtDistance;

	public int cycleSpeed;
	public int cycleTrack; 
	public float speed;

	public NPCDirection? currentDirection;

	public Transform destination;
	NavMeshAgent NavAgent;

	public Animator MyAnimator { get; private set; }
	
	public RuntimeAnimatorController controller;

	public SpriteRenderer spriteRenderer;

	public float AnimationSpeed;

	public enum NPCDirection
	{
		Left, 
		Right,
		Forward,
		Backward, 
		Stop,
		Looking,
	}

	public Transform[] World1Locations = new Transform[4];
	public Transform[] World2Locations = new Transform[4];
	public Transform[] World3Locations = new Transform[4];
	public Transform[] World4Locations = new Transform[4];
	public Transform[] World5Locations = new Transform[4];

	Transform[] currentLocations;
	// Use this for initialization
	void Start () {

		camera = MainCamera.Instance.transform;
		player = PlayerController.MyTransform;
		spriteRenderer = GetComponent < SpriteRenderer >();
		MyAnimator = GetComponent < Animator >();
		NavAgent = GetComponent < NavMeshAgent > ();

		if (MyAnimator.runtimeAnimatorController == null){
			MyAnimator.runtimeAnimatorController = controller;
		}

		if (lookAtDistance == 0){
			lookAtDistance = 1;
		}

		if (cycleSpeed == 0){
			cycleSpeed = 125;
		}

		if (speed == 0){
			speed = 0.01f;
		}

		if (AnimationSpeed == 0){
			AnimationSpeed = .5f;
		}

		isMoving = true;
		cycleTrack = Random.Range (cycleSpeed - 22, cycleSpeed + 31);
		NavAgent.baseOffset = 3.0f;
		NavAgent.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Case when player is within the lookAt range
		if (Vector3.Distance(this.transform.position, player.position) < lookAtDistance){
			if (currentDirection != NPCDirection.Looking){
				LookAtPlayer();
				StopMoving(NPCDirection.Looking);
				return;
			}
			else {
				this.transform.LookAt(camera);
				return;
			}
		}

		if (destination){
			if (Vector3.Distance (this.transform.position, destination.position) < lookAtDistance) {
				destination = null;
				transform.rotation = Quaternion.identity;
				StopMoving (); 
				NavAgent.enabled = false;
			} else {
				NavAgent.enabled = true;
				NavAgent.destination = destination.position;
				MyAnimator.Play ("OutFocusAnim");
				transform.rotation = Quaternion.identity;
				return;
			}
		}
		if (isStealthy && spriteRenderer.isVisible){
			MyAnimator.Play ("IdleAnim");
			currentDirection = NPCDirection.Stop;
			return;
		}

		//Other cases and stuff
		else if (currentDirection == NPCDirection.Looking){
			this.transform.rotation = Quaternion.identity;
			isMoving = true;
			ChooseDirection(Random.Range(0, 5));

			MyAnimator.Play("OutFocusAnim");
			ChangeAnimation("FocusAnim", "IdleAnim");
		}

		else if ((cycleTrack <= 0) && (isMoving)){
			StopMoving();
		}
		else if ((cycleTrack <= 0) && (!isMoving)){
			ChooseDirection(Random.Range(0, 5));

			if (currentDirection == NPCDirection.Stop){
				cycleTrack--;
				return;
			}
			isMoving = true;

			MyAnimator.Play("OutFocusAnim");
			ChangeAnimation("FocusAnim", "IdleAnim");
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

		MyAnimator.Play("IntoFocusAnim");
		ChangeAnimation("IntoFocusAnim", "FocusAnim");
	}

	void LookAtPlayer(){
		this.transform.LookAt(camera);

		MyAnimator.Play("IntoFocusAnim");
		ChangeAnimation("IntoFocusAnim", "FocusAnim");
	}

	void ChangeAnimation(string oldState, string newState){
		MyAnimator.SetBool(oldState, false);
		MyAnimator.SetBool(newState, true);
	}

	//Sets the destination for the NPC based on time of current day. Called by DayNightCycle object in scene
	void changeLocation(int t){
		if (currentLocations.Length != 4) {
			Debug.Log("NPC Positions not properly set for NPC \"" + this.name + "\"");
			return;
		}
		switch (t) {
		case 0: //Dawn
			destination = currentLocations [0];
			break;
		case 1: //Noon
			destination = currentLocations [1];
			break;
		case 2: //Dusk
			destination = currentLocations [2];
			break;
		case 3: //Midnight
			destination = currentLocations [3];
			break;
		}
	}

	//Sets the locations for the NPC to visit for the current day. 
	void changeDay(float totalDays){
		//int totalDays = CheckTime.Instance.totalDays;

		if (totalDays < 10) { //First World State
			currentLocations = World1Locations;
		} else if (totalDays >= 10 && totalDays < 16) { //Second World State
			currentLocations = World2Locations;
		} else if (totalDays >= 16 && totalDays < 21) { //Third World State
			currentLocations = World3Locations;
		} else if (totalDays >= 21 && totalDays < 28) { //Fourth World State
			currentLocations = World4Locations;
		} else {
			currentLocations = World5Locations;
		}
	}
}
