using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _attackRange = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance == null)
            return;
        
        var direction = Player.Instance.transform.position - transform.position;
        transform.position += direction.normalized * (_speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Player.Instance.transform.position) < _attackRange)
        {
            Destroy(gameObject);
            Destroy(Player.Instance.gameObject);
        }
    }
}
