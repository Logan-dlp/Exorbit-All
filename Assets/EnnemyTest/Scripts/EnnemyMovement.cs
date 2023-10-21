using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _positionArray;
    [SerializeField] private float _smooth;
    [SerializeField] private float _distanceChangeIndex;

    private int _index = 1;

    private void Start()
    {
        transform.position = _positionArray[0].position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, _positionArray[_index].position, _smooth);
        if (Vector3.Distance(transform.position, _positionArray[_index].position) < _distanceChangeIndex)
        {
            if (_index+1 < _positionArray.Length)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }
        }
    }
}
