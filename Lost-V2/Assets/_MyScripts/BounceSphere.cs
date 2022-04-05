using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSphere : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    [SerializeField] float currentHeight;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(initialPosition.x, currentHeight + Mathf.Sin(Time.time * frequency) * amplitude, initialPosition.z);
    }
}
