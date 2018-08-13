using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class EnemyProjectile : MonoBehaviour {
        public float speed;

        // Use this for initialization
        void Start() {
			transform.LookAt(Player.player.transform.position);
			this.DoAfterTime(()=>Destroy(gameObject),10);
		}

		// Update is called once per frame
		void Update() {
			transform.Translate(transform.right*speed*Time.deltaTime);
		}
	}
}