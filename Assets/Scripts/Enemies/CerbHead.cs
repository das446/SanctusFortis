using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class CerbHead : Enemy {

		Cerburus c;
		private void Start() {
			c = GetComponentInParent<Cerburus>();
		}
		public override void GetHit(int damage) {

			c.GetHit(damage);
		}

	}
}