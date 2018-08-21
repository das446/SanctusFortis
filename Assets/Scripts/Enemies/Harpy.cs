using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Harpy : Enemy {

		void Start() {
			base.Start();
			StartCoroutine(Dive());

		}

		void Update() {

		}

		IEnumerator Dive() {
			while (true) {
				
				yield return new WaitForSeconds(10);
				float time = 4;
				Vector3 target = Player.player.transform.position;
				Vector3 dir = transform.position - target;
				dir = dir.normalized*speed;
				while (time > 0) {
					transform.position-=dir*Time.deltaTime;
					time -= Time.deltaTime;
					yield return new WaitForEndOfFrame();
				}
				yield return null;
			}
			
		}

	}
}