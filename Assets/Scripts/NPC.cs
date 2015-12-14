using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {

		camera = MainCamera.Instance.transform;
		player = PlayerController.MyTransform;
		spriteRenderer = GetComponent<SpriteRenderer>();
		MyAnimator = GetComponent<Animator>();

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

		else if (isStealthy && spriteRenderer.isVisible){
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
}
