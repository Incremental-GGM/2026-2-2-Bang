using TMPro;
using UnityEngine;

namespace _01_Scripts
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private int money;
        public int Money 
        { 
            get => money;
            set 
            { 
                money = value; 
                moneyDisplayTmp.text = $"{frontText} {money.ToString()}"; 
            } 
        }
        [SerializeField] private TextMeshProUGUI moneyDisplayTmp;
        [SerializeField] private string frontText;

        public void AddMoney(int v)
        {
            Money += v;
        }
    }
}