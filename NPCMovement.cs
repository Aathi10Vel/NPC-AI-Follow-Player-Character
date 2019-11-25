using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPCMovement : MonoBehaviour {

    public Transform followPlayer;
    Animator npcAnim;
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public CharacterController npcController;
    public Vector3 ctrlVelocity;
    float npcGrav = 20.0f;
    public bool isPlayerRunning = false;
    public bool isPlayerIdle = true;
    public bool isPlayerAction = false;
    float npcPosition;

    public void Start()
    {
        npcAnim = GetComponent <Animator>();
        npcController = gameObject.GetComponent<CharacterController>();
    }

    public void Update()
    {
        npcMoving();
    }

    public void npcMoving()
    {
        Vector3 direction = followPlayer.position - npcController.transform.position;
        float angle = Vector3.Angle(direction, npcController.transform.position);
        npcPosition = Vector3.Distance(followPlayer.position, npcController.transform.position);
        
        if (( isPlayerAction == true && npcPosition > 10) || (isPlayerAction == false && npcPosition > 3))
        { 
            direction.y = 0;
            npcController.transform.rotation = Quaternion.Slerp(npcController.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if (direction.magnitude > 1)
            {
                Debug.Log("NPC Position :- " + npcPosition);

                if((isPlayerRunning || isPlayerIdle || !isPlayerRunning) && npcPosition > 10)
                {
                    npcMove(direction, runSpeed);
                    isRunForward();
                }
                else
                {
                    npcMove(direction, walkSpeed);
                    isMoveForward();
                }
            }
        }
        else
        {
            isIdle();
        }
    }

    void npcMove(Vector3 dir, float spd)
    {
        ctrlVelocity = dir.normalized * spd;
        ctrlVelocity.y = Mathf.Clamp(npcController.velocity.y, -30, 2);
        ctrlVelocity.y -= npcGrav * Time.deltaTime;
        npcController.Move(ctrlVelocity * Time.deltaTime);
    }

    void isRunForward()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", true);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveForward()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", true);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isRunBackward()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", true);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveBack()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", true);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveLeft()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", true);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveRight()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", true);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isIdle()
    {
        npcAnim.SetBool("isIdle", true);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveForRight()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", true);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", true);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveForLeft()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", true);
        npcAnim.SetBool("isWalkLeft", true);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveBackLeft()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", true);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", true);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isMoveBackRight()
    {
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", true);
        npcAnim.SetBool("isWalkBack", true);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isLaying()
    {
        npcAnim.SetBool("isLaying", true);
        npcAnim.SetBool("isStandUp", false);
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", true);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isStandUp()
    {
        npcAnim.SetBool("isLaying", false);
        npcAnim.SetBool("isStandUp", true);
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", true);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
        npcAnim.SetBool("isJump", false);
    }

    void isJump()
    {
        npcAnim.SetBool("isJump", true);
        npcAnim.SetBool("isLaying", false);
        npcAnim.SetBool("isStandUp", false);
        npcAnim.SetBool("isIdle", false);
        npcAnim.SetBool("isWalkFront", false);
        npcAnim.SetBool("isWalkLeft", false);
        npcAnim.SetBool("isWalkRight", false);
        npcAnim.SetBool("isWalkBack", false);
        npcAnim.SetBool("isWalkBackFear", false);
        npcAnim.SetBool("isRunForward", false);
        npcAnim.SetBool("isRunBackward", false);
    }

}
