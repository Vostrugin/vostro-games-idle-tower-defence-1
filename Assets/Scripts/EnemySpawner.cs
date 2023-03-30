using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private float _spawnRadius = 5f;
        
        private float _currentCooldown;

        private void Update()
        {
            _currentCooldown += Time.deltaTime;
            
            if (_currentCooldown >= _spawnInterval)
            {
                Spawn();
                _currentCooldown = 0f;
            }
        }

        private void Spawn()
        {
            var insideUnitSphere = Random.insideUnitSphere;
            insideUnitSphere.y = 0;
            
            var randomOffset = insideUnitSphere.normalized * _spawnRadius;
            var position = transform.position + new Vector3(randomOffset.x, 0f, randomOffset.z);

            Instantiate(_enemyPrefab, position, Quaternion.identity);
        }
    }
}