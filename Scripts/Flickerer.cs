using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickerer : MonoBehaviour
{
    private Light light;
    private GameObject volumetricLightBeam;
    private GameObject lampShade;
    private Light _light;
    private float originalIntensity;
    private bool isCurrentlyFlickering;
    private float CycleCount = 6;
    public float MaxFlickerIntensityMultiplier;
    public float LongFlickerChance;
    public float ShortFlickerChance;
    public float ErraticFlickerChance;

    // 

    void Start()
    {
        light = GetComponentInChildren<Light>();
        if (light != null)
        {
            Debug.Log("We have the light!");
        }
        volumetricLightBeam = new List<GameObject>(GameObject.FindGameObjectsWithTag("VolumetricLightBeam")).Find(g => g.transform.IsChildOf(transform));
        if (volumetricLightBeam != null)
        {
            Debug.Log("We have the beam!");
        }
        lampShade = new List<GameObject>(GameObject.FindGameObjectsWithTag("LampShade")).Find(g => g.transform.IsChildOf(transform));
        if (lampShade != null)
        {
            Debug.Log("We have the lampshade!");
        }
        //volumetricLights = GetComponentsInChildren<VolumetricLightBeam>();
        //originalIntensity = _light.intensity;
        //originalIntensity = light.intensity;

        StartCoroutine(FlickeringLight());
    }

    void Update()
    {
        if (!isCurrentlyFlickering)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    private void setLights(bool state)
    {
        light.gameObject.SetActive(state);
        volumetricLightBeam.SetActive(state);
        lampShade.SetActive(state);
    }

    IEnumerator FlickeringLight()
    {
        //Debug.Log("long blink");
        for (int i = 0; i < 6; i++)
        {
            isCurrentlyFlickering = true;
            float delay;
            // Long flicker
            delay = Random.Range(1f, 1.5f);
            setLights(true);
            yield return new WaitForSeconds(delay);
            delay = Random.Range(0.05f, 0.1f);
            setLights(false);
            yield return new WaitForSeconds(delay);
        }
        //Debug.Log("short blink");

        for (int i = 0; i < CycleCount; i++)
        {
            for (int n = 0; n < 2; n++)
            {
                isCurrentlyFlickering = true;
                float delay;
                delay = Random.Range(0.01f, 0.1f);
                setLights(true);
                yield return new WaitForSeconds(delay);
                delay = Random.Range(0.01f, 0.2f);
                setLights(false);
                yield return new WaitForSeconds(delay);
            }
        }
        isCurrentlyFlickering = false;
    }
}
