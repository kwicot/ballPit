using System;
using UnityEngine;

namespace Kwicot.Controllers.Obstacles
{
    public class ObstacleLeftRight : ObstacleBase
    {
        public float radius;
        public float speed;
        private Vector3 startPos;
        private Vector3 dir;
        private Rigidbody rb;
        public enum Types
        {
            X,
            Z
        }

        public Types type = Types.X; 

        private void Start()
        {
            startPos = transform.position;
            rb = GetComponent<Rigidbody>();
            if(type == Types.X) dir = Vector3.left;
            else dir = Vector3.forward;
        }

        private void Update()
        {
            if (type == Types.X)
            {
                if (dir == Vector3.left)
                    if (transform.position.x < (startPos.x - radius))
                        dir = Vector3.right;

                if (dir == Vector3.right)
                    if (transform.position.x > (startPos.x + radius))
                        dir = Vector3.left;
            }
            else
            {
                if (dir == Vector3.forward)
                    if (transform.position.z > (startPos.z + radius))
                        dir = Vector3.back;

                if (dir == Vector3.back)
                    if (transform.position.z < (startPos.z - radius))
                        dir = Vector3.forward;
            }


            rb.velocity = dir * speed;
        }
    }
}