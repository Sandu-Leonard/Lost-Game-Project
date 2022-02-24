using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    Transform destination;
    [SerializeField]
    GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        player.transform.position = destination.position;
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
    }


}
