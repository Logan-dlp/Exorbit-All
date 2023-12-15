using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    private Rigidbody _rb;
    private Vector3 direction;
    private Transform crosshaireObjectPosition;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        crosshaireObjectPosition = GameObject.FindWithTag("Crosshaire").transform;
        direction = crosshaireObjectPosition.position;
        Vector3 _targetPosition = direction - transform.position;
        Quaternion _rotation = Quaternion.LookRotation(_targetPosition);
        transform.rotation = _rotation;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnnemyConfig>(out EnnemyConfig ennemyConfig))
        {
            ennemyConfig.Damage(_damage);
            if (ennemyConfig.IsDead())
            {
                Destroy(ennemyConfig.gameObject);
            }
        }
    }
}
