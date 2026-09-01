using DevLib.ObjectPool.Runtime;
using UnityEngine;

namespace _01_Scripts.Element
{
    public class Arrow : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public PoolItemSO PoolItem { get; set; }
        public GameObject GameObject => gameObject;
        private bool _isFire;
        private float _speed;
        
        public void ResetItem()
        {
            
        }

        public void Fire(float speed)
        {
            _speed = speed;
            _isFire = true;
        }
        
        private void Update()
        {
            if (!_isFire) return;
            transform.position += transform.right * (_speed * Time.deltaTime);
        }
    }
}