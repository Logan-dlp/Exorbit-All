using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject crosshaireObject;
    [SerializeField] private Vector2 crosshaireScreenSize;
    

    private void Start()
    {
        controller = GetComponent<PlayerInput>();
        
        InputAction _mouvement = controller.actions["Movement"];
        _mouvement.performed += MovementPerformed;
        _mouvement.canceled += MouvementCanceled;
    }

    private void Update()
    {
        CrosshaireMovement();
    }

    private void CrosshaireMovement()
    {
        crosshaireObject.transform.position = new Vector3(
            Mathf.Clamp(crosshaireObject.transform.position.x + crosshairPosition.x, -crosshaireScreenSize.x + transform.position.x, crosshaireScreenSize.x + transform.position.x), 
            Mathf.Clamp(crosshaireObject.transform.position.y + crosshairPosition.y, -crosshaireScreenSize.y + transform.position.y, crosshaireScreenSize.y + transform.position.y), 
            crosshaireObject.transform.position.z);
    }

    
    
    // Input.
    private void MovementPerformed(InputAction.CallbackContext _ctx)
    {
        crosshairPosition = _ctx.ReadValue<Vector2>() * Time.deltaTime * crosshairSpeed;
    }

    private void MouvementCanceled(InputAction.CallbackContext _ctx)
    {
        crosshairPosition = Vector2.zero;
    }
}
