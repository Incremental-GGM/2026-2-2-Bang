using TMPro;
using UnityEngine;

namespace _01_Scripts.UI
{
    public class MoneyPlusEvent : MonoBehaviour
    {
        [SerializeField] public MoneyManager moneyManager;
        
        public void MoneyPlus()
        {
            moneyManager.AddMoney(1);
        }
    }
}