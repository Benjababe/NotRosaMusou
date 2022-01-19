using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controls
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;

        public AudioSource gunshotSound;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                Shoot();
        }

        private void Shoot()
        {
            gunshotSound.Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}