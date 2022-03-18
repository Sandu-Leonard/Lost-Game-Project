using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    Rigidbody rigidbody;
    BoxCollider boxCollider;
    [SerializeField] float arrowSpeed = 300f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        rigidbody.AddRelativeForce(new Vector3(0, 0, arrowSpeed));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("HIT!");
            Destroy(gameObject);
            //respawn player
        }
    }
}
