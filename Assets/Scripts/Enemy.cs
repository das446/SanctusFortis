using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Enemy : MonoBehaviour {

		public int health;
		public float speed=1;

		void Update() {
			transform.position = Vector2.MoveTowards(transform.position, Player.player.transform.position,speed*Time.deltaTime);
		}

		public void GetHit(int damage) {
			health -= damage;
			if (health <= 0) {
				Die();
			}
		}

		private void Die() {
			Destroy(gameObject);
		}
	}
}