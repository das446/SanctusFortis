using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class DamagePlayer : MonoBehaviour {

		public int amnt;
		public bool destroyOnHit;

		private void OnCollisionEnter2D(Collision2D other) {
			Player p = other.gameObject.GetComponent<Player>();
			if (p != null) {
				p.TakeDamage(amnt);
				if (destroyOnHit) {
					Destroy(gameObject);
				}
			}

		}
		
	}
}