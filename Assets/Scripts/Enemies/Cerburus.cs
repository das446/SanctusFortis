using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Cerburus : Enemy {

		float startHealth;
		public GameObject head1,head2,head3;
		public EnemyProjectile projectile;
		float shootTime = 1;

		void Start () {
			startHealth = health;
			StartCoroutine(Shoot());
		}

		void Update(){
			Move();
		}

        private void Move()
        {
           transform.position=Vector2.MoveTowards(transform.position,Player.player.transform.position,speed*Time.deltaTime);
        }

        new void GetHit(int amnt){
			health -= amnt;
			if(health<=0){
				Die();
			}
			else if(health<startHealth*2/3 && head1!=null){
				Destroy(head1);
				head1=null;
				shootTime=shootTime*2/3;
			}
			else if(health<startHealth*1/3 && head2!=null){
				Destroy(head2);
				head2=null;
				shootTime=shootTime/2;
			}
		}

		IEnumerator Shoot(){
			while(true){
				Instantiate(projectile,head3.transform.position,Quaternion.identity);
				yield return new WaitForSeconds(shootTime);
			}

		}


	}
}