using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePhysics
{
    public class CameraTrack : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed = 0.125F;

        private void LateUpdate()
        {
            if (target != null)
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}