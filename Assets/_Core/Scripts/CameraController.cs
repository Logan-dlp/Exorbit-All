using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Crosshaire Object")]
    [SerializeField] private Transform crosshaireObjectPosition;
    [Header("Smooth Camera Settings")]
    [SerializeField] private float cameraStartRotationX;
    [SerializeField] private float cameraStartRotationY;
    [SerializeField] private float cameraClampRotation;
    [SerializeField] private float smoothRotationDelay;

    private void Update()
    {
        CameraSmoothRotation(crosshaireObjectPosition, cameraStartRotationX, cameraStartRotationY, cameraClampRotation, smoothRotationDelay);
    }

    private void CameraSmoothRotation(Transform _targetObject, float _startRotationX, float _startRotationY,float _clampRotation, float _delayRotation)
    {
        float _rotationX = _targetObject.position.y;
        float _rotationY = _targetObject.position.x;
        
        Debug.Log(_rotationX);

        _rotationX = Mathf.Clamp(_rotationX, -_clampRotation + _startRotationX, _clampRotation + _startRotationX);
        _rotationY = Mathf.Clamp(_rotationY, -_clampRotation - _startRotationY, _clampRotation + _startRotationY);
        
        Debug.Log(_rotationX);
        
        Quaternion _target = Quaternion.Euler(-_rotationX * 100, _rotationY * 10, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, _target, Time.deltaTime * _delayRotation);
    }
}
