using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    /*
     * Clamp du viseur a revoir / adapter le viseur 2D
     * gestion de tire
     * camera qui bouge un peu (voir proj orlog)
     */
    
    private PlayerInput controller;
    private Vector2 crosshairPosition = Vector2.zero;
    [SerializeField] private float crosshairSpeed = 5;
    [SerializeField] private GameObject crosshaireObject;

    private void Start()
    {
        controller = GetComponent<PlayerInput>();
        
        InputAction _mouvement = controller.actions["Movement"];
        _mouvement.performed += MovementPerformed;
        _mouvement.canceled += MouvementCanceled;
    }

    private void Update()
    {
        crosshaireObject.transform.position = new Vector3(
            crosshaireObject.transform.position.x + Mathf.Clamp(crosshairPosition.x, -10, 10),
            crosshaireObject.transform.position.y + Mathf.Clamp(crosshairPosition.y, -5, 5),
            crosshaireObject.transform.position.z);// clamp à revoir !
    }

    void MovementPerformed(InputAction.CallbackContext _ctx)
    {
        crosshairPosition = _ctx.ReadValue<Vector2>() * Time.deltaTime * crosshairSpeed;
    }

    void MouvementCanceled(InputAction.CallbackContext _ctx)
    {
        crosshairPosition = Vector2.zero;
    }
}
