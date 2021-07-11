using System;
using UnityEngine;

namespace Kwicot.Controllers.Obstacles
{
    public class ObstacleStationaryRotation : ObstacleBase
    {
        public float speed;


        private float h;
        private void Update()
        {
            h += Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0,h,0);
        }
    }
}