using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerConfig : MonoBehaviour
{
    private int _life = 100;
    public int Life => _life;

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
}
