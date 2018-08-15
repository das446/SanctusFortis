using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Harpy : Enemy {

		void Start() {
			StartCoroutine(Dive());

		}

		void Update() {

		}

		IEnumerator Dive() {
			while (true) {
				yield return new WaitForSeconds(10);
				float time = 5;
				Vector2 target = Player.player.transform.position;
				while (time > 0) {
					transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
					time -= Time.deltaTime;
					yield return new WaitForEndOfFrame();
				}
				yield return null;
			}
			
		}

	}
}