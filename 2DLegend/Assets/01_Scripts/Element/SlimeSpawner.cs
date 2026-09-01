using System;
using UnityEngine;
using System.Collections;

namespace _01_Scripts.Element
{
    public class SlimeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject slimePrefab;
        [SerializeField] private float coolTime = 5f;

        private bool _canSpawn = true;

        private void Update()
        {
            if (!_canSpawn) return;

            GameObject a = Instantiate(slimePrefab);
            a.transform.position = transform.position;
            StartCoroutine(SpawnCoolTime());
        }

        private IEnumerator SpawnCoolTime()
        {
            _canSpawn = false;
            yield return new WaitForSeconds(coolTime);
            _canSpawn = true;
        }
    }
}