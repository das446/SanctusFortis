using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class BigHarpy : Enemy {

		public GameObject[] walls;

		public Gear gear;



		

		protected override void Die(){
			Gear g = Instantiate(gear,transform.position,transform.rotation);
			g.walls = walls;
			base.Die();


		}
	}
}