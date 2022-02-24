using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactDistance = 10f;

    public bool isTheTextDisplayed;
    public GameObject uiText;
    private void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Ray ray = new Ray(transform.position, transform.forward);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, interactDistance))
        //    {
        //        if (hit.collider.CompareTag("Door"))
        //        {
        //            hit.collider.transform.GetComponent<KeyDoor>().OpenCloseDoor();
        //        }

        //    }
        //}


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OutsideTable")
        {
            if (!isTheTextDisplayed)
                StartCoroutine(TextDisplay());
        }
    }

    IEnumerator TextDisplay()
    {
        uiText.SetActive(true);
        isTheTextDisplayed = true;
        yield return new WaitForSeconds(5f);
        isTheTextDisplayed = false;
        uiText.SetActive(false);

    }


}
