using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 direction;
    private Transform crosshaireObjectPosition;
    
    private void Start()
    {
        crosshaireObjectPosition = GameObject.FindWithTag("Crosshaire").transform;
        direction = crosshaireObjectPosition.position;
        Vector3 _targetPosition = direction - transform.position;
        Quaternion _rotation = Quaternion.LookRotation(_targetPosition);
        transform.rotation = _rotation;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }
}
