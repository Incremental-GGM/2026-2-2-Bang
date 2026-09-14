using System;

namespace _01_Scripts.Element
{
    [Serializable]
    public struct UpgradeData
    {
        public string id;
        public string displayName;
        public BigNumber initialCost;
        public float costMultiplier;
        public int maxLevel;
        public UpgradeEffect effects;
    }
}