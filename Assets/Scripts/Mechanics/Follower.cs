using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePhysics;

public class Follower : MonoBehaviour
{
    public float movementSpeed = 3F;
    public GameObject followee;
    private Vector3 _lastPos;
    private Transform _transform;

    private bool _isLeft = true;
    private Character _c;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _c = GetComponent<Character>();
    }

    private void LateUpdate()
    {
        if (followee == null)
            return;

        if (_lastPos.x != followee.transform.position.x)
        {
            _lastPos = followee.transform.position;
            Follow();
        }
    }

    private void Follow()
    {
        float distance = followee.transform.position.x - transform.position.x;

        if (Mathf.Abs(distance) < 0.75F)
            return;

        float movement = movementSpeed;
        if (distance < 0)
            movement *= -1;

        Vector3 velocity = new Vector3(movement, 0, 0) * Time.deltaTime;
        transform.position += velocity;

        if (Mathf.Abs(movement) > 0)
            _isLeft = _c.CheckOrientation(_transform, movement, _isLeft);
    }
}
