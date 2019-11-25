using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCamera : MonoBehaviour {

	public Transform targetPlayer;


	Camera playerCamera;

	public Vector2 mouseLook;
	public Vector2 rotateVert;
	public float sensitivity=5.0f;
	public float smoothing=2.0f;

	public Vector3 lookOffset;

	public Quaternion camRotate;
	public Quaternion camRotateX;
	public Quaternion camRotateLock;

	public float cameraDistance=2.0f;

	public Vector3 positionCam;

	public PlayerMove checkAction;


	private Vector3 curVelocity=Vector3.zero;


	private float smoothVel=10.0f;
	private float smoothTime=5.0f;

	void Start(){
		checkAction = FindObjectOfType<PlayerMove> ();
		playerCamera = GetComponent<Camera> ();
		lookOffset = playerCamera.transform.position-targetPlayer.transform.position;
	}

	void Update(){

	
		
			Cursor.visible = false;
			var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

			md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
			rotateVert.x = Mathf.Lerp (rotateVert.x, md.x, 1f / smoothing);
			rotateVert.y = Mathf.Lerp (rotateVert.y, md.y, 1f / smoothing);
			mouseLook += rotateVert;
			mouseLook.y = Mathf.Clamp (mouseLook.y, -70, 50);

			//For Both X and Y Rotation of Camera
			camRotate = Quaternion.Euler (-mouseLook.y, mouseLook.x, 0);

			//For Only X Rotation of Camera
			camRotateX = Quaternion.Euler (0, mouseLook.x, 0);

			

			if (checkAction.actionPerform==true) {
				
				targetPlayer.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (targetPlayer.transform.eulerAngles.y, camRotate.eulerAngles.y, ref smoothVel, smoothTime * Time.deltaTime);
			} else {
				
				Vector3 lookPoint = targetPlayer.transform.position;
				playerCamera.transform.LookAt (lookPoint + lookOffset);
			}

            positionCam = targetPlayer.position - (camRotate * Vector3.forward * cameraDistance + new Vector3(0, -lookOffset.y, 0));

      	
			playerCamera.transform.rotation = camRotate;
			playerCamera.transform.position = positionCam;

	}
		
}
