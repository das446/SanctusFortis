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

		public FirePlatform[] platforms;

		void Start() {
			base.Start();
			startHealth = health;
			StartCoroutine(Shoot());
		}

		void Update() {
			if (Player.player.transform.position.x > transform.position.x) {
				transform.eulerAngles = new Vector3(0, 180, 0);
			} else {
				transform.eulerAngles = Vector3.zero;
			}
			Move();
		}

		private void Move() {
			transform.position = Vector2.MoveTowards(transform.position, Player.player.transform.position, speed * Time.deltaTime);
		}

		public override void GetHit(int amnt) {
			base.GetHit(amnt);

			if (health < 66 && health > 30 && head1.activeSelf) {
				head1.SetActive(false);
				shootTime = shootTime * 2 / 3;
				StartCoroutine(FirePlatforms());
			}
			if (health < 30 && head2.activeSelf) {
				head2.SetActive(false);
				shootTime = shootTime * 2 / 3;
			}

		}

		private IEnumerator FirePlatforms() {
			while (health > 0) {
				FirePlatform fp = platforms.RandomItem();
				StartCoroutine(fp.TurnOn(6, 2));
				yield return new WaitForSeconds(8);
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