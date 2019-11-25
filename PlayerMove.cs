using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	Animator charAnim;
	
    

	public float moveForwardSpeed=4.0f;
	public float runForwardSpeed=20.0f;
	public float moveBackwardSpeed=4.0f;
	private Vector3 moveDirection=Vector3.zero;
	public CharacterController charPlayer;

	public bool isRunning=false;
	public float playerGravity = 20.0f;
	
	private float vSpeed=0;

	public bool actionPerform;

	

    public NPCMovement NPCPlayerMove; 


	// Use this for initialization
	void Start () {
		charAnim = GetComponent<Animator> ();
		charPlayer = GetComponent<CharacterController> ();
	}


	// Update is called once per frame
	void Update () {

		playerMovement ();
		playerIdle ();
	}

	void playerIdle(){
		if (charAnim.GetBool ("isIdle") == true) {
			actionPerform = false;
            NPCPlayerMove.isPlayerAction = false;
		}

        if (!actionPerform)
        {
            NPCPlayerMove.isPlayerIdle = true;
        }
        else
        {
            NPCPlayerMove.isPlayerIdle = false;
        }

    }

	void playerMovement(){

	
		moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		

		vSpeed -= playerGravity * Time.deltaTime;
		moveDirection.y = vSpeed;

		actionPerform = true;
        NPCPlayerMove.isPlayerAction = true;
		
		isIdle ();
		isRunning = false;

		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey (KeyCode.W)) {
			moveDirection *= runForwardSpeed;
			isRunning = true;
			isRunForward ();
			
		}else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
		{
			moveDirection *= runForwardSpeed;
			isRunning = true;
			isRunBackward();
			
		}
		else if (Input.GetKey(KeyCode.W)) {
			moveDirection *= moveForwardSpeed;
			isMoveForward ();
			
		}
		else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
		{
			moveDirection *= moveForwardSpeed;
			isMoveForLeft();
			
		}
		else if (Input.GetKey(KeyCode.A)) {
			moveDirection *= moveBackwardSpeed;
			isMoveLeft ();
			
		}
		else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
		{
			moveDirection *= moveForwardSpeed;
			isMoveForRight();
			
		}
		else if (Input.GetKey(KeyCode.D)) {
			moveDirection *= moveBackwardSpeed;
			isMoveRight ();
			
		}
		else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{
			moveDirection *= moveBackwardSpeed;
			isMoveBackRight();
			
		}
		else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
		{
			moveDirection *= moveBackwardSpeed;
			isMoveBackLeft();
			
		}
		else if(Input.GetKey(KeyCode.S)){
			moveDirection *= moveBackwardSpeed;
			isMoveBack ();
			
		}
		

		charPlayer.Move (moveDirection * Time.deltaTime);

        if (actionPerform && isRunning)
        {
            NPCPlayerMove.isPlayerRunning = true;
        }
        else
        {
            NPCPlayerMove.isPlayerRunning = false;
        }

    

    }


    void isRunForward()
    {
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", true);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveForward(){
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", true);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isRunBackward(){
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", true);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveBack(){
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", true);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveLeft(){
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", true);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveRight(){
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", true);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isIdle(){
		charAnim.SetBool ("isIdle", true);
		charAnim.SetBool ("isWalkFront", false);
		charAnim.SetBool ("isWalkLeft", false);
		charAnim.SetBool ("isWalkRight", false);
		charAnim.SetBool ("isWalkBack", false);
		charAnim.SetBool ("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveForRight()
    {
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", true);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", true);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveForLeft()
    {
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", true);
        charAnim.SetBool("isWalkLeft", true);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", false);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveBackLeft()
    {
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", true);
        charAnim.SetBool("isWalkRight", false);
        charAnim.SetBool("isWalkBack", true);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

    void isMoveBackRight()
    {
        charAnim.SetBool("isIdle", false);
        charAnim.SetBool("isWalkFront", false);
        charAnim.SetBool("isWalkLeft", false);
        charAnim.SetBool("isWalkRight", true);
        charAnim.SetBool("isWalkBack", true);
        charAnim.SetBool("isWalkBackFear", false);
        charAnim.SetBool("isRunForward", false);
        charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
    }

	void isLaying(){
		charAnim.SetBool ("isLaying", true);
		charAnim.SetBool ("isStandUp", false);
		charAnim.SetBool("isIdle", false);
		charAnim.SetBool("isWalkFront", false);
		charAnim.SetBool("isWalkLeft", false);
		charAnim.SetBool("isWalkRight", true);
		charAnim.SetBool("isWalkBack", false);
		charAnim.SetBool("isWalkBackFear", false);
		charAnim.SetBool("isRunForward", false);
		charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
	}

	void isStandUp(){
		charAnim.SetBool ("isLaying", false);
		charAnim.SetBool ("isStandUp", true);
		charAnim.SetBool("isIdle", false);
		charAnim.SetBool("isWalkFront", false);
		charAnim.SetBool("isWalkLeft", false);
		charAnim.SetBool("isWalkRight", true);
		charAnim.SetBool("isWalkBack", false);
		charAnim.SetBool("isWalkBackFear", false);
		charAnim.SetBool("isRunForward", false);
		charAnim.SetBool("isRunBackward", false);
		charAnim.SetBool ("isJump", false);
	}

	void isJump(){
		charAnim.SetBool ("isJump", true);
		charAnim.SetBool ("isLaying", false);
		charAnim.SetBool ("isStandUp", false);
		charAnim.SetBool("isIdle", false);
		charAnim.SetBool("isWalkFront", false);
		charAnim.SetBool("isWalkLeft", false);
		charAnim.SetBool("isWalkRight", false);
		charAnim.SetBool("isWalkBack", false);
		charAnim.SetBool("isWalkBackFear", false);
		charAnim.SetBool("isRunForward", false);
		charAnim.SetBool("isRunBackward", false);
	}


}
