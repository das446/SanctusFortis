using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Skeleton : Enemy {

		public bool walkOff;
		bool right;

		private void Start() {
			base.Start();
			if (walkOff) {
				GetComponent<SpriteRenderer>().color = Color.gray;
			}
		}

		void Update() {
			Move();
		}

		private void Move() {

			Vector3 dir = right ? Vector2.right : Vector2.left;

			bool ledge = !Physics2D.Raycast(transform.position + dir * 0.5f, Vector2.down, 1, 1 << 9);

			if (ledge && !walkOff && Grounded()) {
				TurnAround();
			} else {
				transform.Translate(dir * speed * Time.deltaTime, Space.World);
			}
		}

		bool Grounded() {
			return Physics2D.Raycast(transform.position, Vector2.down, 1, 1 << 9);
		}

		void TurnAround() {
			transform.Rotate(0, 180, 0);
			right = !right;
		}
	}
}