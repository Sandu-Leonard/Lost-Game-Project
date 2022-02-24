using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimationTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Animator anim;

    private void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
                anim.SetTrigger("Jump");
           // }
        }
    }
}
