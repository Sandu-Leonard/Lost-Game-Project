using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{ 
    BoxCollider boxCollider;
    [SerializeField]Rigidbody rigidB;
    [SerializeField] float arrowSpeed = 300f;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        rigidB.AddRelativeForce(new Vector3(0, 0, arrowSpeed));
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
