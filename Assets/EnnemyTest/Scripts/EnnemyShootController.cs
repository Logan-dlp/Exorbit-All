using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnnemyShootController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private int _damage = 5;
    private Rigidbody _rb;
    
    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerConfig>(out PlayerConfig playerConfig))
        {
            playerConfig.Damage(_damage);
            Debug.Log(playerConfig.Life);
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Sheild")
        {
            Destroy(gameObject);
        }
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
