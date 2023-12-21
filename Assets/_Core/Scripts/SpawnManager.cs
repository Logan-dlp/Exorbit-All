using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private GameObject _ennemieGameObject;
    [SerializeField] private GameObject _bossGameObject;
    [SerializeField] private PlayerConfig _playerConfig;
    
    public List<GameObject> ennemieInGameList;
    
    private void Start()
    {
        _statsManager.handle = 0;
        _statsManager.score = 0;
        _statsManager.handleWithBoss = 0;
        
        ennemieInGameList = new List<GameObject>();
    }

    private void Update()
    {
        if (ennemieInGameList.Count == 0)
        {
            _playerConfig.Heal(100);
            _statsManager.handle++;
            if ( _statsManager.handle % 3 == 0)
            {
                GameObject newBoss = Instantiate(_bossGameObject, Vector3.zero, Quaternion.identity);
                EnnemyMovement ennemyBossMovement = newBoss.GetComponent<EnnemyMovement>();
                int random = Random.Range(5, 20);
                ennemyBossMovement.positionArrayLoop = new Vector3[random];
                for (int i = 0; i < random; i++)
                {
                    ennemyBossMovement.positionArrayLoop[i] = SetRandomPosition();
                }
                ennemieInGameList.Add(newBoss);
                
                for (int i = 0; i < _statsManager.handleWithBoss; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        GameObject newEnnemie = Instantiate(_ennemieGameObject, Vector3.zero, Quaternion.identity);
                        EnnemyMovement ennemyMovement = newEnnemie.GetComponent<EnnemyMovement>();
                        random = Random.Range(5, 15);
                        ennemyMovement.positionArrayLoop = new Vector3[random];
                        for (int k = 0; k < random; k++)
                        {
                            ennemyMovement.positionArrayLoop[k] = SetRandomPosition();
                        }
                        ennemieInGameList.Add(newEnnemie);
                    }
                }
                
                _statsManager.handleWithBoss++;
            }
            else
            {
                for (int i = 0; i < _statsManager.handle - _statsManager.handleWithBoss; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        GameObject newEnnemie = Instantiate(_ennemieGameObject, Vector3.zero, Quaternion.identity);
                        EnnemyMovement ennemyMovement = newEnnemie.GetComponent<EnnemyMovement>();
                        int random = Random.Range(5, 15);
                        ennemyMovement.positionArrayLoop = new Vector3[random];
                        for (int k = 0; k < random; k++)
                        {
                            ennemyMovement.positionArrayLoop[k] = SetRandomPosition();
                        }
                        ennemieInGameList.Add(newEnnemie);
                    }
                }
            }
        }
    }

    private Vector3 SetRandomPosition()
    {
        float x = Random.Range(-163, 163);
        float y = Random.Range(20, 75);
        float z = Random.Range(-410, -265);

        return new Vector3(x, y, z);
    }

    private void SetPositionAtEnnemie(EnnemyMovement ennemyMovement)
    {
        for (int i = 0; i < ennemyMovement.positionArrayLoop.Length; i++)
        {
            ennemyMovement.positionArrayLoop[i] = SetRandomPosition();
        }
    }
}
