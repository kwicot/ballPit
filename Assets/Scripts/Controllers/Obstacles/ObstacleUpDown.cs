using UnityEngine;
using UnityEngine.Serialization;

namespace Kwicot.Controllers.Obstacles
{
    public class ObstacleUpDown : ObstacleBase
    {
        public float high;
        public float speed;
        private Vector3 startPos;
        private Vector3 dir = Vector3.up;
        private Rigidbody rb;

        private void Start()
        {
            startPos = transform.position;
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (dir == Vector3.up)
                if(transform.position.y > (startPos.y+high)) dir = Vector3.down;

            if (dir == Vector3.down)
                if(transform.position.y < startPos.y) dir = Vector3.up;
            
            
            rb.velocity = dir * speed;
        }
    }
}