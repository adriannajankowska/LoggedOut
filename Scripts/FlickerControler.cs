using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//[InitializeOnLoad]
public class FlickerControler : MonoBehaviour
{
	private bool flickeringStarted = false;
	public Material material;
	private GameObject[] lightBeams;

    void Start()
    {
        material.EnableKeyword("_EMISSION");
        lightBeams = GameObject.FindGameObjectsWithTag("TrafficLightBeam");
        FlickerTheTrafficLights();
    }

    void FlickerTheTrafficLights()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true) { 
            material.DisableKeyword("_EMISSION");
            for (int j = 0; j < lightBeams.Length; j++)
            {
                lightBeams[j].SetActive(false);
            }

            yield return new WaitForSeconds(1f);

            material.EnableKeyword("_EMISSION");
            for (int j = 0; j < lightBeams.Length; j++)
            {
                lightBeams[j].SetActive(true);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}