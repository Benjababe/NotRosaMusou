using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePhysics;

namespace Controls
{
    public class Character2DController : MonoBehaviour
    {
        [SerializeField] private LayerMask platformLayerMask;
        public float movementSpeed = 3.0F;
        public float jumpForce = 3.0F;

        private Transform _transform;
        private Rigidbody2D _rigidBody;
        private BoxCollider2D _boxCollider;

        private bool _isLeft = false;

        private Character _c;

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
            _c = GetComponent<Character>();
        }

        private void Update()
        {
            float movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

            if (Mathf.Abs(movement) > 0)
                _isLeft = _c.CheckOrientation(_transform, movement, _isLeft);

            if (Input.GetButtonDown("Jump") && _c.IsGrounded(_boxCollider, platformLayerMask))
            {
                _rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
