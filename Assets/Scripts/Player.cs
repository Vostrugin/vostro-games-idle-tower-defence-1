using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Cannon _cannon;
    
    private List<GameObject> _enemiesInRange = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Attack();

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Attack()
    {
        _enemiesInRange.RemoveAll(x => x == null);
        
        if (_enemiesInRange.Count == 0)
            return;

        _cannon.Attack(_enemiesInRange[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemiesInRange.Add(other.gameObject);
        }
    }
}
