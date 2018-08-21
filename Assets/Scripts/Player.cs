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
		public float fallMultiplier = 2.5f;
		public float lowJumpMultiplier = 2;
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
		public BoxCollider2D col;

		public Animator anim;

		bool pressJump;
		bool holdJump;

		void Start() {
			this.InvokeRepeatingWhile(RepeatHeal, 1, () => health > 0);
			player = this;
			col = GetComponent<BoxCollider2D>();

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

			pressJump = Input.GetKeyDown(KeyCode.UpArrow);
			holdJump = Input.GetKey(KeyCode.UpArrow);

			if (Input.GetKeyDown(KeyCode.X)) {
				FlipGravity();
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				SwordAttack();
			}
		}

		private void FixedUpdate() {

			Jump();
		}

		void FlipGravity() {

			if (!PayHealth(10)) { return; }
			//PayHealth(100);

			flipped = !flipped;

			//rb.gravityScale *= -1;

			Vector2 v = rb.velocity;
			v.y /= 2;
			rb.velocity = v;
			Vector3 r = transform.eulerAngles;
			r.z = flipped ? 180 : 0;
			r.y = r.y + 180;
			transform.eulerAngles = r;

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
			if (!shielding) {
				Vector2 v = rb.velocity;
				v.x /= 2;
				rb.velocity = v;
			}
			shielding = true;
			sprite.color = Color.blue;
		}

		void StopShielding() {
			shielding = false;
			sprite.color = Color.white;
		}

		public bool CanJump() {
			return Physics2D.Raycast(transform.position, -transform.up, 0.75f, 1 << 9);
		}

		public void Move() {
			float x = Input.GetAxis("Horizontal");
			if (shielding) {
				return;
			}

			if (!Wall(x)) {
				Vector2 v = rb.velocity;
				v.x = Vector2.right.x * x * speed;
				rb.velocity = v;
				anim.SetFloat("Speed", x);
			}
			if (x != 0) {
				Vector3 r = transform.eulerAngles;
				r.y = x > 0 != flipped ? 0 : 180;
				transform.eulerAngles = r;

			}
		}

		private bool Wall(float x) {

			return false; //until I get it working

			Vector2 dir = x > 0 ? Vector2.right : Vector2.left;

			return Physics2D.BoxCast(transform.position, col.size, 0, dir, 0.5f, 1 << 9);
		}

		private bool CanMove() {
			return !shielding;
		}

		public void Jump() {

			int g = flipped? - 1 : 1;

			if (pressJump && CanJump()) {

				Vector3 v = rb.velocity;
				rb.AddForce(Vector2.up * jumpForce * g, ForceMode2D.Impulse);
				Debug.Log("Jump");
			}
			float relativeY = rb.velocity.y * g;

			Debug.Log(relativeY);

			if (relativeY < 0) {
				rb.gravityScale = fallMultiplier * g;

			} else if (relativeY > 0 && !holdJump) {
				rb.gravityScale = lowJumpMultiplier * g;

			} else {
				rb.gravityScale = g;
			}
		}

		public void LoseHealth(int v) {
			health -= v;
			if (health <= 0) {
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