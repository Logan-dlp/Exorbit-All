using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class SemiProceduralMapsManager : MonoBehaviour
{
    [SerializeField] private float Speed = -5;
    [SerializeField] private int HeightMapsAssets = 10;
    [SerializeField] private GameObject[] MapsAssets;
    private float[] rotationPossible = { 0, 90, 180, 270 };
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, Speed * Time.deltaTime);

        if (transform.position.z <= -500)
        {
            Vector3 _pos = new Vector3(0, 0, transform.position.z + 500);
            Instantiate(RandomMapsAssets(), _pos, Quaternion.Euler(RandomRotationMaps()));
            Destroy(gameObject);
        }
    }

    private GameObject RandomMapsAssets()
    {
        int _rand = Random.Range(0, MapsAssets.Length);
        return MapsAssets[_rand];
    }

    private Vector3 RandomRotationMaps()
    {
        int _rand = Random.Range(0, rotationPossible.Length);
        Debug.Log(rotationPossible[_rand]); // a suppr qd on utilise les protos de maps...
        return new Vector3(-90, rotationPossible[_rand], 0);
    }
}
