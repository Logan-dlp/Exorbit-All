using System;
using System.Collections;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _life = 100;
    public int Life => _life;

    [SerializeField, Range(0, 100)] private float _shield = 0;
    public float Shield => _shield;

    [SerializeField] private GameObject _sheildGameObject;
    [SerializeField] private int _timeToRechargeSheild = 1;

    public bool UseSheild = false;
    public bool SheildIsFull = false;

    private void Update()
    {
        if (_shield < 100 && !UseSheild)
        {
            _shield += _timeToRechargeSheild * Time.deltaTime;
        }

        if (_shield > 99.9f)
        {
            SheildIsFull = true;
        }
        
        ActiveSheild();
    }

    public void Heal(int lifeHeal)
    {
        _life += lifeHeal;
    }
    
    public void Damage(int lifeDamage)
    {
        _life -= lifeDamage;
        Debug.Log("damage");
    }

    public bool IsDead()
    {
        if (Life <= 0)
        {
            return true;
        }
        return false;
    }

    public void ActiveSheild()
    {
        if (_shield > 0 && UseSheild)
        {
            _sheildGameObject.SetActive(true);
            _shield -= _timeToRechargeSheild * Time.deltaTime;
        }
        else if (UseSheild)
        {
            _sheildGameObject.SetActive(false);
            UseSheild = false;
            SheildIsFull = false;
        }
    }
}
