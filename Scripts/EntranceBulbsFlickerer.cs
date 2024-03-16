using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//[InitializeOnLoad]
public class EntranceBulbsFlickerer : MonoBehaviour
{
    private bool flickeringStarted = false;
    public Material bulbMaterial1;
    public Material bulbMaterial2;
    public Material bulbMaterial3;

    void Start()
    {
        bulbMaterial1.DisableKeyword("_EMISSION");
        bulbMaterial2.DisableKeyword("_EMISSION");
        FlickerTheBulbs();
    }

    void FlickerTheBulbs()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            bulbMaterial3.DisableKeyword("_EMISSION");
            bulbMaterial1.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(1f);
            bulbMaterial1.DisableKeyword("_EMISSION");
            bulbMaterial2.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(1f);
            bulbMaterial2.DisableKeyword("_EMISSION");
            bulbMaterial3.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(1f);
        }
    }
}