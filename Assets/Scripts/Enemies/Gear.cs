using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Gear : MonoBehaviour {

		public GameObject[] walls;
		public RuntimeAnimatorController Normal;

		void Start () {
			
		}
		
		void Update () {
			
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.GetComponent<Player>()!=null){
				GetPickedUp();
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.GetComponent<Player>()!=null){
				GetPickedUp();
			}
		}

		void GetPickedUp(){
			foreach(GameObject wall in walls){
				Destroy(wall);
			}
			Player.player.anim.runtimeAnimatorController=Normal;
			Destroy(gameObject);
		}
	}
}