using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePhysics;

namespace Mechanics
{
    public class Enemy : MonoBehaviour
    {
        public bool isLeft = true;
        public float health = 100F;
        public float movementSpeed = 1.5F;
        public float attackCooldown = 3F;
        public int attackDamage = 40;
        public int score = 100;
        public GameObject deathEffect;
        public AudioSource hitSound;
        private Score _scoreCounter;
        private GameObject _player;
        private SpriteRenderer _renderer;
        private Character _c;
        private float _timer;

        private void Start()
        {
            _scoreCounter = GameObject.Find("ScoreCounter").GetComponent<Score>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _renderer = GetComponent<SpriteRenderer>();
            _c = GetComponent<Character>();
            _timer = 0;
        }

        private void LateUpdate()
        {
            if (_player == null)
                return;

            Transform target = _player.transform;
            float distance = target.position.x - transform.position.x;

            _timer += Time.deltaTime;

            if (Mathf.Abs(distance) > 1.25)
                Move(distance);
            else
                Attack();
        }

        private void Move(float distance)
        {
            float movement = movementSpeed;
            if (distance < 0)
                movement *= -1;

            Vector3 velocity = new Vector3(movement, 0, 0) * Time.deltaTime;
            transform.position += velocity;
            isLeft = _c.CheckOrientation(transform, movement, isLeft);
        }

        private void Attack()
        {
            if (_timer > attackCooldown)
            {
                _player.GetComponent<Player>().Damage(attackDamage);
                _timer = 0;
            }
        }

        public void Damage(float damage)
        {
            health -= damage;
            hitSound.Play();
            if (health <= 0)
                Die();
        }

        private void Die()
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            _scoreCounter.Increment(score);

            _renderer.enabled = false;
            ShiftEnemy();
            hitSound.Play();
            Invoke("DestroyEnemy", hitSound.clip.length);
        }

        private void ShiftEnemy()
        {
            transform.position = new Vector3(1000, 1000, 1000);
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}