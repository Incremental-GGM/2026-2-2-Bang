using System;
using UnityEngine;

namespace _01_Scripts.Element
{
    public class HpManager : MonoBehaviour
    {
        [field: SerializeField] public BigNumber MaxHp { get; private set;}
        [field: SerializeField] public BigNumber Hp { get; private set;}

        public event Action OnChangeHp;
        public event Action OnDied;

        public void ApplyDamage(BigNumber hp)
        {
            Hp -= hp;
        }
    }
}