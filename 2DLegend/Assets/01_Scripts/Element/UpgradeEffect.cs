namespace _01_Scripts.Element
{
    public class UpgradeEffect
    {
        public UpgradeEffectType Type;
        public float Amount = 1;
        
        public UpgradeEffect(UpgradeEffectType attackType, int attack)
        {
            Type = attackType;
        }
    }
}