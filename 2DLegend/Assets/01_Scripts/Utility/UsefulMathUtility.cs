using UnityEngine;

namespace _01_Scripts.Utility
{
    public static class UsefulMathUtility
    {
        public static BigNumber initialCost;
        public static float costMultiplier;
        
        public static BigNumber CalculateCost(int level)
        {
            return initialCost * Mathf.Pow(costMultiplier, level);
        }
    }
}