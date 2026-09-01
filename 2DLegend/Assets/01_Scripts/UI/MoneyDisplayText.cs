using TMPro;
using UnityEngine;

namespace _01_Scripts.UI
{
    public class MoneyDisplayText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyDisplayTmp;

        public void ChangeMoneyDisplayText(string content)
        {
            moneyDisplayTmp.text = content;
        }
    }
}