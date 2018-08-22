using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class FirePlatform : MonoBehaviour {

		bool On = false;
		SpriteRenderer sr;

		private void Start()
		{
			sr = GetComponent<SpriteRenderer>();
		}

		public IEnumerator TurnOn(float time,float delay){
			sr.color = Color.magenta;
			yield return new WaitForSeconds(delay);
			sr.color = Color.red;
			On=true;
			yield return new WaitForSeconds(time);
			On=false;
			sr.color=Color.white;
		}

		private void OnCollisionStay2D(Collision2D other)
		{
			if(On&&other.gameObject.tag=="Player"){
				Player.player.TakeDamage(10);
			}
		}
	}
}