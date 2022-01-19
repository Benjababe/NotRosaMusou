using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mechanics;

namespace GamePhysics
{

    public class Bullet : MonoBehaviour
    {
        public float speed = 10F;
        public float damage = 20F;
        public Rigidbody2D rb2D;

        private void Start()
        {
            rb2D.velocity = transform.right * speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            Bullet bullet = hitInfo.GetComponent<Bullet>();

            if (enemy != null)
                enemy.Damage(damage);

            Destroy(gameObject);
        }
    }
}
