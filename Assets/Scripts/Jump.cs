using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {

	public class Jump : MonoBehaviour {

		public Player player;

		public float jumpForce;
		public float jumpTime;
		public float jumpTimeCounter;

		public bool grounded;
		public LayerMask whatIsGround;
		public bool stoppedJumping;

		public bool pressingJump;
		public bool holdingJump;
		public bool releaseJump;

		public Transform groundCheck;
		public float groundCheckRadius;

		void Start() {
			player = GetComponent<Player>();
			jumpTimeCounter = jumpTime;
		}

		private void Update() {
			pressingJump = Input.GetKeyDown(KeyCode.UpArrow);
			holdingJump = Input.GetKey(KeyCode.UpArrow);
			releaseJump = Input.GetKeyUp(KeyCode.UpArrow);

			grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

			if (grounded) {
				jumpTimeCounter = jumpTime;
			}
		}

		private void FixedUpdate() {
			if (pressingJump && player.CanJump()) {
				player.rb.velocity = new Vector2 (player.rb.velocity.x, jumpForce);
                stoppedJumping = false;
			}
		}

		
	}
}