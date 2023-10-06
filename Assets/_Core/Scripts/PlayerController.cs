using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput)), RequireComponent(typeof(CameraController))]
public class PlayerController : MonoBehaviour
{
    /*
     * gestion de tire
     */
    
    private PlayerInput controller;
    private Vector2 crosshairPosition = Vector2.zero;
    
    [Header("Crosshaire Settings")]
    [SerializeField] private float crosshairSpeed = 5;
    [SerializeField] private Transform crosshaireObjectPosition;
    [SerializeField] private Vector2 crosshaireScreenSize;

    [SerializeField] private bool shoot = false;
    [SerializeField] private GameObject ballObject;
    

    private void Start()
    {
        controller = GetComponent<PlayerInput>();
        
        InputAction _mouvement = controller.actions["Movement"];
        _mouvement.performed += MovementPerformed;
        _mouvement.canceled += MouvementCanceled;

        InputAction _shoot = controller.actions["Shoot"];
        _shoot.performed += ShootPerformed;
        _shoot.canceled += ShootCanceled;
    }

    private void Update()
    {
        CrosshaireMovement();
        Shoot();
    }

    private void CrosshaireMovement()
    {
        crosshaireObjectPosition.transform.position = new Vector3(
            Mathf.Clamp(crosshaireObjectPosition.position.x + crosshairPosition.x, -crosshaireScreenSize.x + transform.position.x, crosshaireScreenSize.x + transform.position.x), 
            Mathf.Clamp(crosshaireObjectPosition.position.y + crosshairPosition.y, -crosshaireScreenSize.y + transform.position.y, crosshaireScreenSize.y + transform.position.y), 
            crosshaireObjectPosition.position.z);
    }

    private void Shoot()
    {
        if (shoot)
        {
            return;
        }
    }

    
    // Input
    private void ShootPerformed(InputAction.CallbackContext _ctx)
    {
        shoot = true;
        Instantiate(ballObject, transform.position, Quaternion.identity);
    }

    private void ShootCanceled(InputAction.CallbackContext _ctx)
    {
        shoot = false;
    }
    
    private void MovementPerformed(InputAction.CallbackContext _ctx)
    {
        crosshairPosition = _ctx.ReadValue<Vector2>() * Time.deltaTime * crosshairSpeed;
    }

    private void MouvementCanceled(InputAction.CallbackContext _ctx)
    {
        crosshairPosition = Vector2.zero;
    }
}
