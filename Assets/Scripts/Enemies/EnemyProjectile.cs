using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class EnemyProjectile : MonoBehaviour {
		public float speed;
		[Tooltip("0 is 100% accurate, higher numbers are less")]
		public float accuracy;

		// Use this for initialization
		void Start() {
			Vector3 offset = new Vector3(Random.Range(-accuracy,accuracy),Random.Range(-accuracy,accuracy),0);
			Vector3 Target = Player.player.transform.position+offset;
			Vector3 dir = Target - transform.position;
			float x = transform.position.x - Target.x;
			float y = transform.position.y - Target.y;
			float s = y / x;
			float theta = Mathf.Atan(s) * Mathf.Rad2Deg;

			if (Target.x > transform.position.x) {

				theta = -(180 - theta);
			}

			transform.eulerAngles = new Vector3(0, 0, theta);
		}

		// Update is called once per frame
		void Update() {
			transform.Translate(-transform.right * speed * Time.deltaTime, Space.World);
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log(other.gameObject);
			other.GetComponent<Player>()?.TakeDamage(10);
			Destroy(gameObject);
		}

		void OnCollisionEnter2D(Collision2D other) {
			Debug.Log(other.gameObject);
			other.gameObject.GetComponent<Player>()?.TakeDamage(10);
			Destroy(gameObject);
		}

		
	}
}