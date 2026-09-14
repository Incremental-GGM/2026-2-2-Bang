using UnityEngine;

namespace _01_Scripts.Element
{
    public class WaveManager : MonoBehaviour
    {
        [field: SerializeField] public int Wave { get; private set; }

        public void NextWave()
        {
            Wave++;
        }
    }
}