using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Enemy : MonoBehaviour {

		public int health;
		public float speed=1;


		public void GetHit(int damage) {
			health -= damage;
			if (health <= 0) {
				Die();
			}
		}

		protected void Die() {
			Destroy(gameObject);
		}

		
	}
}