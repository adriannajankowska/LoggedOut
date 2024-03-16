using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITipsController : MonoBehaviour
{
    //GameObject UITip;
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Enter the collider of pickable object");
        if (collider.tag == "PhoneOnTheGround")
        {
            collider.gameObject.transform.Find("UITip").gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        //Debug.Log("Exited the collider of pickable object");
        if (collider.tag == "PhoneOnTheGround")
        {
            collider.gameObject.transform.Find("UITip").gameObject.SetActive(false);
        }
    }
}
