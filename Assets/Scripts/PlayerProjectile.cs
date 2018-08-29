using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class PlayerProjectile : MonoBehaviour {
		public float speed;
		void Start() {
			Destroy(gameObject, 10);
		}

		void Update() {
			Vector2 dir = transform.eulerAngles.y == 0 ? transform.right : -transform.right;
			transform.Translate(dir * speed * Time.deltaTime);
		}

		void OnCollisionEnter2D(Collision2D other) {
			Debug.Log(other);
			Enemy e = other.gameObject.GetComponent<Enemy>();
			if (e != null) {
				e.GetHit(8);
				Destroy(gameObject);
			}
		}

		void OnTriggerEnter2D(Collider2D other) {
			Enemy e = other.GetComponent<Enemy>();
			if (e != null) {
				e.GetHit(8);
				Destroy(gameObject);
			}
		}
	}
}