using _01_Scripts.UI;
using UnityEngine;

namespace _01_Scripts
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private string startMoneyValue;
        [SerializeField] private MoneyDisplayText moneyDisplayText;
        [SerializeField] private string frontText;

        private BigNumber _money;

        public BigNumber Money
        {
            get => _money;
            set
            {
                _money = value;
                UpdateMoneyDisplay();
            }
        }

        private void Awake()
        {
            Money = BigNumber.FromDouble(double.Parse(startMoneyValue));
        }

        public void AddMoney(BigNumber value)
        {
            Money += value;
        }

        public void AddMoney(double value)
        {
            Money += value;
        }

        private void UpdateMoneyDisplay()
        {
            moneyDisplayText.ChangeMoneyDisplayText(
                $"{frontText} {_money}"
            );
        }
    }
}