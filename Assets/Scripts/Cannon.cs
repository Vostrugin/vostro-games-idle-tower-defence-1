using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _rotationSpeed = 2f;
        
        private Transform _target;
        private float _currentCooldown;
        private bool _isRotationOk;
        
        public void Attack(GameObject target)
        {
            _target = target.transform;
            
            if (_currentCooldown > 0f || !_isRotationOk)
                return;

            var bullet = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Fire(target.transform);
        
            _currentCooldown = 1f;
        }

        private void Update()
        {
            _currentCooldown -= Time.deltaTime * _attackSpeed;

            if (_target != null)
            {
                var targetRotation = _target.transform.position - transform.position;
                targetRotation.y = 0;

                var rotation = Quaternion.LookRotation(targetRotation);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);

                _isRotationOk = Mathf.Abs(transform.rotation.eulerAngles.y - rotation.eulerAngles.y) < 5f;
            }
        }
    }
}