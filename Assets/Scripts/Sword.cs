using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Sword : MonoBehaviour {

		public Transform target;
		public float length = 0.3f;

		private void Update()
		{
			transform.position=target.position;
			
		}


		

		public void Use() {
			transform.position=target.position;
			gameObject.SetActive(true);
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Player.player.transform.right,length,1<<11);
			hit.collider?.gameObject?.GetComponent<Enemy>()?.GetHit(10);
			this.DoAfterTime(PutAway, 0.25f);
			//test
		}

		void PutAway() {
			gameObject.SetActive(false);
		}

	}
}