using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Cerburus : Enemy {

		float startHealth;
		public GameObject head1, head2, head3;
		public EnemyProjectile projectile;
		float shootTime = 1;
		bool invincible = false;

		void Start() {
			startHealth = health;
			StartCoroutine(Shoot());
		}

		void Update() {
			Move();
		}

		private void Move() {
			transform.position = Vector2.MoveTowards(transform.position, Player.player.transform.position, speed * Time.deltaTime);
		}

		public override void GetHit(int amnt) {
			if (!invincible) {
				base.GetHit(amnt);

				if (health < 66 && health > 30) {
					Destroy(head1);
					head1 = null;
					shootTime = shootTime * 2 / 3;
				}
				if (health < 30) {
					Destroy(head2);
					head2 = null;
					shootTime = shootTime * 2 / 3;
				}
				//CHangeColor
				this.DoAfterTime(() => {
					invincible = false;
					//ChangeColor
				}, 3);
			}
		}

		IEnumerator Shoot() {
			while (true) {
				Instantiate(projectile, head3.transform.position, Quaternion.identity);
				yield return new WaitForSeconds(shootTime);
			}

		}

	}
}