using UnityEngine;

public class WallCloseTriger : MonoBehaviour
{
    [SerializeField] Animator animator;

    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            animator.SetTrigger("Close");
        }
    }
}

