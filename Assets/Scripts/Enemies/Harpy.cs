using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Harpy : Enemy {

		SpriteRenderer s;
		void Start() {
			base.Start();
			s = GetComponent<SpriteRenderer>();
			StartCoroutine(Dive());

		}

		void Update() {
			if(transform.position.x<Player.player.transform.position.x){
				s.flipX=true;
			}
		}

		IEnumerator Dive() {
			while (true) {
				
				yield return new WaitForSeconds(UnityEngine.Random.Range(8,10));
				
				Vector3 target = Player.player.transform.position;
				Vector3 dir = transform.position - target;

				LookAtPlayer();

				float time = 5;
				dir = dir.normalized*speed;
				while (time > 0) {
					transform.position-=dir*Time.deltaTime;
					time -= Time.deltaTime;
					yield return new WaitForEndOfFrame();
				}
				
				yield return null;
			}
			
		}

        private void LookAtPlayer()
        {
        }
    }
}