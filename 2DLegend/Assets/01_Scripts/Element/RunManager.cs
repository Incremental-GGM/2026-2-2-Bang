using System;
using UnityEngine;

namespace _01_Scripts.Element
{
    public class RunManager : MonoBehaviour
    {
        [SerializeField] private HpManager hpManager;
        [SerializeField] private GameObject panel;

        private void Awake()
        {
            hpManager.OnDied += EndRun;
        }

        private void EndRun()
        {
            
        }
    }
}