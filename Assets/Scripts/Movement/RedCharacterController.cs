using UnityEngine;
using System.Collections;

public class RedCharacterController : MonoBehaviour
{

		public GameObject camera;
		public float speed = 5.0F;
		public float runSpeed = 10.0F;
		public float rotateSpeed = 5.0F;
		public float jumpSpeed = 2.0F;
		public float gravity = 20.0F;
		private Vector3 moveDirection;
		private Quaternion desiredRotation;
		private Animator anim;

		void Start ()
		{

				anim = GetComponent<Animator> ();

		}

		void Update ()
		{
				CharacterController controller = GetComponent<CharacterController> ();
				//if(controller.isGrounded){
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				moveDirection = camera.transform.TransformDirection (moveDirection);
				moveDirection.y = 0;
				
				float h = Input.GetAxis ("Horizontal");
				float v = Input.GetAxis ("Vertical");		// setup v variables as our vertical input axis
				if (Input.GetButton("Fire1") && Input.GetButton("Fire2")) {
					moveDirection = camera.transform.TransformDirection (new Vector3(Input.GetAxis("Horizontal"),0,1));
					h = 1;
					v = 1;
				}
				anim.SetFloat ("Speed", h);
				anim.SetFloat ("Speed2", v);// set our animator's float parameter 'Speed' equal to the vertical input axis					
				
				//Debug.Log (h);
				if (Input.GetButton ("Sprint")) {
						moveDirection *= speed;
						//moveDirection.z *= runSpeed;
						anim.SetBool ("Shift", true);
				} else {
						anim.SetBool ("Shift", false);
						moveDirection *= runSpeed;
				}
				if (Input.GetButton ("Jump")) {
						moveDirection.y = jumpSpeed;
				}


				if (!controller.isGrounded) {
				moveDirection.y -= gravity;
				}

					
				controller.Move (moveDirection * Time.deltaTime);
				if (controller.velocity != Vector3.zero) {
			desiredRotation = Quaternion.LookRotation (new Vector3 (moveDirection.x+0.0000001f, 0f, moveDirection.z+0.0000001f));
			transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, rotateSpeed * 10 * Time.deltaTime);

				}



		}

		//}
}
