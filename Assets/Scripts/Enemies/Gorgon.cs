using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Gorgon : Enemy {

		bool right;
		public EnemyProjectile projectile;

		private void Start() {
			this.InvokeRepeatingWhile(Shoot, 5, () => true);
		}

		private void Shoot() {
			float r = UnityEngine.Random.Range(0, 4);
			if (r == 0) {
				ShootLazer();
			} else {
				ShootEyeBeam();
			}
			
		}

        private void ShootLazer()
        {
            throw new NotImplementedException();
        }

        private void ShootEyeBeam()
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }

        private void Update() {
			MoveBack();
		}

		private void MoveBack() {
			bool playerToRight = Player.player.transform.position.x - transform.position.x > 0;
			Vector3 dir;
			if (playerToRight) {
				transform.eulerAngles = transform.eulerAngles.setY(0);
				dir = Vector2.left;
			} else {
				transform.eulerAngles = transform.eulerAngles.setY(180);
				dir = Vector2.right;
			}

			bool floor = Physics2D.Raycast(transform.position + dir, Vector2.down, 1, 1 << 9);
			if (floor) {
				transform.Translate(dir * speed * Time.deltaTime, Space.World);
			}
		}
	}
}