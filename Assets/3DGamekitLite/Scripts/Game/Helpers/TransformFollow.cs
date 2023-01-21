using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    public class TransformFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = Vector3.zero;
        private void LateUpdate()
        {
            transform.position = target.position + offset;
           // transform.rotation = target.rotation;
        }
    } 
}
