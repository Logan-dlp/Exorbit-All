using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnnemyMovement))]
public class EnnemyConfig : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private GameObject _objectShoot;
    [SerializeField] private int _life = 100;
    public int Life => _life;
    private PlayerConfig _playerTarget;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _playerTarget = Camera.main.GetComponent<PlayerConfig>();
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        transform.LookAt(_playerTarget.transform);
        IsDead();
    }

    IEnumerator Shoot()
    {
        Instantiate(_objectShoot, transform.position, transform.rotation);
        yield return new WaitForSeconds(Random.Range(1f, 5f));
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
            _statsManager.score += Random.Range(100, 300);
            _spawnManager.ennemieInGameList.Remove(gameObject);
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
