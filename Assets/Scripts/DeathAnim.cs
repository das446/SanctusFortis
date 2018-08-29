using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SanctusFortis {
	public class DeathAnim : MonoBehaviour {

		void Start () {
			Invoke("Reset",0.75f);
			
		}

		void Reset(){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
		
	}
}