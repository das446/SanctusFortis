using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanctusFortis
{
    public class Spike : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<Player>()?.TakeDamage(10);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<Player>()?.TakeDamage(10);
        }
    }
}
