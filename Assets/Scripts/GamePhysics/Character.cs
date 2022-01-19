using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePhysics
{
    public class Character : MonoBehaviour
    {
        public bool IsGrounded(BoxCollider2D boxCollider, LayerMask platformLayerMask)
        {
            float buffer = .3F;
            RaycastHit2D rcHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + buffer, platformLayerMask);
            return rcHit.collider != null;
        }

        public bool CheckOrientation(Transform transform, float movement, bool isLeft)
        {
            if ((movement < 0 && isLeft) || (movement > 0 && !isLeft))
                return isLeft;

            isLeft = movement < 0;
            transform.Rotate(0F, 180F, 0F);
            return isLeft;
        }
    }
}