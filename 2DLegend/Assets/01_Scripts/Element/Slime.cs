using System;
using UnityEngine;

namespace _01_Scripts.Element
{
    public class Slime : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private void Update()
        {
            Vector3 moveDir = -(transform.position).normalized;
            transform.position += moveDir * (moveSpeed * Time.deltaTime);
        }
    }
}