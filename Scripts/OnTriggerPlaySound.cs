using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlaySound : MonoBehaviour
{
    public bool shouldMorningMoodBePlayed = false;
    private GameObject[] griegTriggers;

    private void Awake()
    {
        griegTriggers = GameObject.FindGameObjectsWithTag("GriegTrigger");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GriegTrigger")
        {
            Debug.Log("Enterred the Grieg trigger.");
            foreach (GameObject griegTrigger in griegTriggers)
            {
                griegTrigger.SetActive(false);
            }
            shouldMorningMoodBePlayed = true;
        }
    }
}
