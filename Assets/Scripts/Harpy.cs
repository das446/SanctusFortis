using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Harpy : Enemy {


		void Start()
		{
			this.InvokeRepeatingWhile(Dive,10,()=>true);
		}

		void Update()
		{
			
		}

		void Dive(){
			Vector2 target = Player.player.transform.position;
		}




	}
}