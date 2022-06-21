using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{

    //private int privateInt = 0;
    //public int publicInt = 0;
    //[SerializeField] private int serializedInt = 0;

    //[SerializeField] private GameObject serializedGameObject;
    //[SerializeField] private Animator animator;

    //private BoxCollider boxCollider;

    private void Start()
    {
        //boxCollider = GetComponent<BoxCollider>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
    //[SerializeField] private UnityEvent onEnterRoom;
    //[SerializeField] private UnityEvent onLeaveRoom;
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        onEnterRoom.Invoke();
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    onLeaveRoom.Invoke();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    StopCoroutine(CorutineTest());
    //}

    //IEnumerator CorutineTest()
    //{ 
    //    //code

    //    yield return new WaitForSeconds(5f);

    //}
}
