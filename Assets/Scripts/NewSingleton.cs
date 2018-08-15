using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	public class NewSingleton : MonoBehaviour {

		public static NewSingleton instance;

		// Use this for initialization
		void Start() {
			if (instance == null) {
				instance = this;
			}
		}

		// Update is called once per frame
		void Update() {

		}
	}
}