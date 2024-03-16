using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDropsHissingOnHot : MonoBehaviour
{
    public List<AudioClip> listOfSounds;
    public AudioClip currentClip;
    public AudioSource source;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 3f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        while (true)
        {
            int index = Random.Range(0, listOfSounds.Count);
            currentClip = listOfSounds[index];
            source.clip = currentClip;
            source.PlayOneShot(currentClip, 1);
            //Debug.Log("Now playing track #" + (index + 1));
            yield return new WaitForSeconds(Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays));
        }
    }
}

