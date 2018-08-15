using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class EnemyProjectile : MonoBehaviour {
		public float speed;

		// Use this for initialization
		void Start() {
			Vector3 Target = Player.player.transform.position;
			float x = transform.position.x - Target.x;
			float y = transform.position.y - Target.y;
			float s = y / x;
			float theta = Mathf.Atan(s)*Mathf.Rad2Deg;

			transform.eulerAngles = new Vector3(0, 0, theta);
		}

		// Update is called once per frame
		void Update() {
			transform.Translate(-transform.right * speed * Time.deltaTime,Space.World);
		}

		private void OnCollisionEnter2D(Collision2D other) {
			other.gameObject.GetComponent<Player>()?.TakeDamage(10);
		}
	}
}