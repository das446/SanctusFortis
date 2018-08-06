using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SanctusFortis {

	[RequireComponent(typeof(Rigidbody2D))]
	public class Player : MonoBehaviour {

		public Rigidbody2D rb;
		public float speed;
		public float jumpForce;
		public int health;
		public int maxHealth;
		public SpriteRenderer sr;
		public GameObject projectile;
		public bool flipped = false;
		public Sword sword;
		public Sprite HealthBar;
		public Text HealthText;
		bool shielding = false;
		public SpriteRenderer sprite;
		public static Player player;

		void Start() {
			this.InvokeRepeatingWhile(RepeatHeal, 1, () => health > 0);
			player=this;

		}

		private void RepeatHeal() {
			float m = rb.velocity.magnitude;
			if (m > 0.25f) {
				Heal(1);
			}
		}

		public void Heal(int amnt) {
			health += amnt;
			if (health > maxHealth) {
				health = maxHealth;
			}
		}

		void Update() {
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				Shield();
			} else if (Input.GetKeyUp(KeyCode.DownArrow) && shielding) {
				StopShielding();
			}
			Move();
			if (CanJump() && Input.GetKeyDown(KeyCode.UpArrow)) {
				Jump();
			}

			if (Input.GetKeyDown(KeyCode.X)) {
				FlipGravity();
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				SwordAttack();
			}
		}

		void FlipGravity() {

			if (!PayHealth(10)) { return; }
			//PayHealth(100);

			flipped = !flipped;

			rb.gravityScale *= -1;

			Vector2 v = rb.velocity;
			v.y /= 2;
			rb.velocity = v;
			Vector3 r = transform.eulerAngles;
			r.z = flipped ? 180 : 0;
			r.y=r.y+180;
			transform.eulerAngles=r;

			

			

		}

		/// <returns>Tries paying health and returns whether health was payed succesfully</returns>
		bool PayHealth(int v) {
			if (health > v) {
				health -= v;
				return true;
			} else {
				//this.StopCaller();
				return false;
			}
		}

		void SwordAttack() {
			if (sword.gameObject.activeSelf) { return; }
			sword.Use();

		}
		void ThrowProjectile() {
			if (health > 5) {
				Instantiate(projectile, transform.position, transform.rotation);
				LoseHealth(5);
			}
		}

		void Shield() {
			shielding = true;
			sprite.color = Color.blue;
		}

		void StopShielding() {
			shielding = false;
			sprite.color = Color.white;
		}

		private bool CanJump() {
			return Physics2D.Raycast(transform.position, -transform.up, 0.75f, 1 << 9);
		}

		public void Move() {
			float x = CanMove() ? Input.GetAxis("Horizontal") : 0;
			Vector2 v = rb.velocity;
			v.x = Vector2.right.x * x * speed;
			rb.velocity = v;
			if (x != 0) {
				Vector3 r = transform.eulerAngles;
				r.y = x > 0 != flipped ? 0 : 180;
				transform.eulerAngles = r;
			}
		}

		private bool CanMove() {
			return !shielding;
		}

		public void Jump() {
			Vector2 v = transform.up;
			rb.AddForce(v * jumpForce);
		}

		

		public void LoseHealth(int v) {
			health -= v;
			if (v <= 0) {
				Die();
			}

		}

		private void Die() {
			Destroy(gameObject);
		}

		public void TakeDamage(int amnt) {
			health -= amnt;
			if (health <= 0) {
				Die();
			}
		}
	}
}