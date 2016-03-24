using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{

	public static Transform camera;
	public static Transform player;

	public bool isMoving;
	public bool isStealthy;

	public float lookAtDistance;

	public int cycleSpeed;
	public int cycleTrack;
	public float speed;

	public NPCDirection? currentDirection;

	public GameObject destinationObj;
	public bool charDisabled;

	NavMeshAgent NavAgent;

	public Animator MyAnimator { get; private set; }

	public RuntimeAnimatorController controller;

	SpriteRenderer spriteRenderer;
	Collider MyCollider;
	Dialogue dialogueScript;

	public float AnimationSpeed;

	public enum NPCDirection
	{
		Left,
		Right,
		Forward,
		Backward,
		Stop,
		Looking,
		ChangeLocation,
	}

	public Transform[] World1Locations = new Transform[4];
	public Transform[] World2Locations = new Transform[4];
	public Transform[] World3Locations = new Transform[4];
	public Transform[] World4Locations = new Transform[4];
	public Transform[] World5Locations = new Transform[4];

	Transform[] currentLocations;
	// Use this for initialization
	void Start ()
	{

		camera = MainCamera.Instance.transform;
		player = PlayerController.MyTransform;
		spriteRenderer = GetComponent < SpriteRenderer > ();
		MyCollider = GetComponent < Collider > ();
		MyAnimator = GetComponent < Animator > ();
		NavAgent = GetComponent < NavMeshAgent > ();
		NavAgent.stoppingDistance = lookAtDistance;

		dialogueScript = GetComponentInChildren< Dialogue > ();

		if (MyAnimator.runtimeAnimatorController == null) {
			MyAnimator.runtimeAnimatorController = controller;
		}

		if (lookAtDistance == 0) {
			lookAtDistance = 1;
		}

		if (cycleSpeed == 0) {
			cycleSpeed = 125;
		}

		if (speed == 0) {
			speed = 2.5f;
		}

		if (AnimationSpeed == 0) {
			AnimationSpeed = .5f;
		}

		isMoving = true;
		cycleTrack = Random.Range (cycleSpeed - 22, cycleSpeed + 31);
		NavAgent.baseOffset = 3.0f;
		NavAgent.autoBraking = true;
		NavAgent.speed = speed/5;

		destinationObj = new GameObject ();
		destinationObj.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//When the character should be off, but isn't and is currently not on screen
		if (charDisabled && spriteRenderer.enabled && !spriteRenderer.isVisible) {
			ToggleVisible (false);
		//When the character should be on, but isn't and is currently not on screen
		} else if (!charDisabled && !spriteRenderer.enabled && !spriteRenderer.isVisible) {
			ToggleVisible (true);
		}
		//Case when player is within the lookAt range
		if (Vector3.Distance (this.transform.position, player.position) < lookAtDistance) {
			if (currentDirection != NPCDirection.Looking) {
				LookAtPlayer ();
				StopMoving (NPCDirection.Looking);
				return;
			} else {
				this.transform.LookAt (camera);
				return;
			}
		}
		//If the character shouldn't be moving
		if (!isMoving) {
			cycleTrack--;
		}
		//If the character isn't within lookAtDistance of their NavAgent destination
		else if (Vector3.Distance (this.transform.position, NavAgent.destination) > lookAtDistance) {
			//If they're 'stealthy' but they're on screen
			if (isStealthy && spriteRenderer.isVisible) {
				MyAnimator.Play ("IdleAnim");
				currentDirection = NPCDirection.Stop;
				return;
			}
			isMoving = true;
			MyAnimator.Play ("OutFocusAnim");
			transform.rotation = Quaternion.identity;
			cycleTrack--;
		//If they ARE within lookAtDistance of their NavAgent destination
		} else {
			if (isMoving) {
				if (currentDirection == NPCDirection.ChangeLocation) {
					currentDirection = NPCDirection.Stop;
				}
				StopMoving ();
			}
			transform.rotation = Quaternion.identity;
		}

		//If they were looking at the player but are no longer
		if (currentDirection == NPCDirection.Looking) {
			this.transform.rotation = Quaternion.identity;
			isMoving = true;
			ChooseDirection (Random.Range (0, 5));
			MyAnimator.Play ("OutFocusAnim");
			ChangeAnimation ("FocusAnim", "IdleAnim");
		//If they were moving but the cycle ended
		} else if ((cycleTrack <= 0) && (isMoving)) {
			StopMoving ();
		//If they weren't moving and the cycle ended
		} else if ((cycleTrack <= 0) && (!isMoving)) {
			ChooseDirection (Random.Range (0, 5));

			if (currentDirection == NPCDirection.Stop) {
				cycleTrack--;
				return;
			}
			isMoving = true;

			MyAnimator.Play ("OutFocusAnim");
			ChangeAnimation ("FocusAnim", "IdleAnim");
		}
		cycleTrack--;
	}

	void ChooseDirection (int i)
	{
		cycleTrack = Random.Range (cycleSpeed - 20, cycleSpeed + 27);

		if (currentDirection == NPCDirection.ChangeLocation) {
			NavAgent.Resume ();
			return;
		}
		currentDirection = (NPCDirection)i;
		SetNavAgentDestination ();
		NavMeshHit hit;
		if (NavAgent.Raycast (destinationObj.transform.position, out hit)) {
			destinationObj.transform.position = hit.position;
			NavAgent.destination = hit.position;
		}

	}

	void SetNavAgentDestination ()
	{
		switch (currentDirection) {		
		case NPCDirection.Left:
			destinationObj.transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
			NavAgent.destination = destinationObj.transform.position;
			break;

		case NPCDirection.Right:
			destinationObj.transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
			NavAgent.destination = destinationObj.transform.position;
			break;

		case NPCDirection.Forward:
			destinationObj.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed);
			NavAgent.destination = destinationObj.transform.position;
			break;

		case NPCDirection.Backward:
			destinationObj.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
			NavAgent.destination = destinationObj.transform.position;
			break;
		default:
			break;
		}
	}

	void StopMoving (NPCDirection newDirection = NPCDirection.Stop)
	{
		isMoving = false;
		cycleTrack = Random.Range (cycleSpeed - 25, cycleSpeed + 30);
		MyAnimator.Play ("IntoFocusAnim");
		ChangeAnimation ("IntoFocusAnim", "FocusAnim");

		if (currentDirection == NPCDirection.ChangeLocation) {
			NavAgent.Stop ();
			return;
		}
		currentDirection = newDirection;
		NavAgent.destination = this.transform.position;
	}

	void LookAtPlayer ()
	{
		this.transform.LookAt (camera);

		MyAnimator.Play ("IntoFocusAnim");
		ChangeAnimation ("IntoFocusAnim", "FocusAnim");
	}

	void ChangeAnimation (string oldState, string newState)
	{
		MyAnimator.SetBool (oldState, false);
		MyAnimator.SetBool (newState, true);
	}

	//Sets the destination for the NPC based on time of current day. Called by DayNightCycle object in scene
	void changeLocation (int t)
	{
		if (currentLocations.Length != 4) {
			Debug.Log ("NPC Positions not properly set for NPC \"" + this.name + "\"");
			return;
		}
		// 0 == Dawn; 1 == Noon; 2 == Dusk; 3 == Midnight
		NavAgent.enabled = true;
		if (currentLocations [t] == null) {
			charDisabled = true;
		} else {
			charDisabled = false;
			destinationObj.transform.position = currentLocations [t].position;
			NavAgent.destination = destinationObj.transform.position;
			currentDirection = NPCDirection.ChangeLocation;
			isMoving = true;
		}
	}

	//Sets the locations for the NPC to visit for the current day.
	void changeDay (float totalDays)
	{
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

	void ToggleVisible (bool t)
	{
		spriteRenderer.enabled = t;

		if (dialogueScript) {
			dialogueScript.enabled = t;
		}
	}
}
