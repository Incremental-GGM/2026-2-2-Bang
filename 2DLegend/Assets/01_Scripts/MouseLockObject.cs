using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _01_Scripts
{
    public class MouseLockObject : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        private void Update()
        {
            transform.right = GetMousePosition();
        }

        private Vector2 GetMousePosition()
        {
            Vector2 mouse = Mouse.current.position.ReadValue();
            
            if (cam == null) return default;
            
            Vector2 mousePosition = cam.ScreenToWorldPoint(mouse);
            Vector2 dir = mousePosition - (Vector2)transform.position;

            return dir.normalized;
        }
    }
}