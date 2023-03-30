using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _explosionDistance = 1f;

    private Transform _target;
    private bool _isFired;

    public void Fire(Transform target)
    {
        _target = target;
        _isFired = true;
    }
    
    void Update()
    {
        if (!_isFired)
            return;
        
        if (_target == null)
        {
            Destroy(gameObject);
        }

        var direction = _target.position - transform.position;
        transform.position += direction.normalized * (_speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) < _explosionDistance)
        {
            Destroy(gameObject);
            Destroy(_target.gameObject);
        }
    }
}
