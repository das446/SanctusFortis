using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class Sword : MonoBehaviour {

		public Transform target;
		public float length = 3;



		

		public void Use() {
			gameObject.SetActive(true);
			this.DoAfterTime(PutAway, 0.25f);
			//test
		}

		void PutAway() {
			gameObject.SetActive(false);
		}

	}
}