using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SanctusFortis {
	public class Enemy : MonoBehaviour {

		public int health;
		public float speed = 1;
		bool vulnerable = true;
		public SpriteRenderer[] sr;

		[Header("Hit Flash")]
		public float flashTime = 0.125f;
		public int flashAmnt = 2;

		protected void Start() {
			var s1 = GetComponent<SpriteRenderer>();
			sr = GetComponentsInChildren<SpriteRenderer>().ToList().Append(s1).ToArray();
		}

		public virtual void GetHit(int damage) {

			if (!vulnerable) { return; }
			health -= damage;
			if (health <= 0) {
				Die();
			} else {
				StartCoroutine(Flash());
			}
		}

		protected virtual void Die() {
			Player.player.Heal(10);
			Destroy(gameObject);
		}

		IEnumerator Flash() {
			vulnerable = false;
			for (int i = 0; i < 2; i++) {

				foreach (SpriteRenderer s in sr) {
					s.enabled = false;
				}

				yield return new WaitForSeconds(flashTime);
				foreach (SpriteRenderer s in sr) {
					s.enabled = true;
				}
				yield return new WaitForSeconds(flashTime);
			}
			vulnerable = true;
		}
		

	}
}