using System;
using UnityEngine;

namespace _01_Scripts.Element
{
    public class Trigger : MonoBehaviour
    {
        public event Action OnAnimationTriggered;
        
        public void AnimationTriggered() => OnAnimationTriggered?.Invoke();
    }
}