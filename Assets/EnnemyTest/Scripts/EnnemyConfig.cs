using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnnemyMovement))]
public class EnnemyConfig : MonoBehaviour
{
    [SerializeField] private GameObject _objectShoot;
    [SerializeField] private int _life = 100;
    public int Life => _life;
    [SerializeField] private float _shootTime;
    private PlayerConfig _playerTarget;

    private void Start()
    {
        _playerTarget = Camera.main.GetComponent<PlayerConfig>();
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        transform.LookAt(_playerTarget.transform);

        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(_objectShoot, transform.position, transform.rotation);
        yield return new WaitForSeconds(_shootTime);
        StartCoroutine(Shoot());
    }

    public void Damage(int lifeDamage)
    {
        _life -= lifeDamage;
    }

    public bool IsDead()
    {
        if (Life <= 0)
        {
            return true;
        }
        return false;
    }
}
