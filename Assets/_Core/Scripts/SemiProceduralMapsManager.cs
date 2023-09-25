using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class SemiProceduralMapsManager : MonoBehaviour
{
    [SerializeField] private float speed = -5;
    [SerializeField] private int heightMapsAssets = 10;
    [SerializeField] private GameObject[] mapsAssets;
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
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);

        if (transform.position.z <= -heightMapsAssets)
        {
            Vector3 _pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + heightMapsAssets);
            Instantiate(RandomMapsAssets(), _pos, Quaternion.Euler(RandomRotationMaps()));
            Destroy(gameObject);
        }
    }

    private GameObject RandomMapsAssets()
    {
        int _rand = Random.Range(0, mapsAssets.Length);
        return mapsAssets[_rand];
    }

    private Vector3 RandomRotationMaps()
    {
        int _rand = Random.Range(0, rotationPossible.Length);
        return new Vector3(-90, rotationPossible[_rand], 0);
    }
}
