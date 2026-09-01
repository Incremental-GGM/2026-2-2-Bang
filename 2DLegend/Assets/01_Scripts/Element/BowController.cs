using System.Collections;
using DevLib.AnimatorSystem;
using DevLib.ObjectPool.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _01_Scripts.Element
{
    public class BowController : MonoBehaviour
    {
        [SerializeField] private PoolManagerSO poolManager;
        [SerializeField] private PoolItemSO arrowPoolItem;
        [SerializeField] private float fireRate;
        [SerializeField] private float arrowSpeed;
        [SerializeField] private Trigger trigger;
        [SerializeField] private HashDataSO idleHash;
        [SerializeField] private HashDataSO loadHash;
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            trigger.OnAnimationTriggered += ArrowFire;
        }

        private void OnDestroy()
        {
            trigger.OnAnimationTriggered -= ArrowFire;
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _animator.Play(loadHash.HashValue);
            }
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                _animator.Play(idleHash.HashValue);
            }
        }

        private void ArrowFire()
        {
            Arrow arrow = poolManager.Pop<Arrow>(arrowPoolItem);
            arrow.transform.rotation = transform.rotation;
            arrow.transform.position = transform.position;
            arrow.Fire(arrowSpeed);
            StartCoroutine(ArrowRate(arrow));
        }
        
        private IEnumerator ArrowRate(Arrow arrow)
        {
            yield return new WaitForSeconds(5f);
            poolManager.Push(arrow);
        }
    }
}