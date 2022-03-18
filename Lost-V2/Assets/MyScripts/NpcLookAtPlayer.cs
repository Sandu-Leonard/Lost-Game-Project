using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLookAtPlayer : MonoBehaviour
{
    public Transform player;
    private Animator anim;
    public bool ikActive = true;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        anim = transform.GetComponent<Animator>(); 
    }

    void OnAnimatorIK()
    {
        if (anim)
        {
            if (ikActive)
            {
                if (player != null)
                {
                    anim.SetLookAtWeight(1);
                    anim.SetLookAtPosition(player.position);
                }
            }
            else
            {
                anim.SetLookAtWeight(0);
            }
        }

    }
}
