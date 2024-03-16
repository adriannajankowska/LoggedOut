using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    //when the next level is loading the sound will fade out and fade in again
    public bool isNextLevelLoading = false;
    //how fast should the global sound fade out while changing scenes
    public float musicFadeOutSpeed;
    //main character object with other scripts (and variables) attached 
    public GameObject mainCharacter;
    //how many dialogue texts are there to be triggered during the current scene
    private int dialogueTriggersCount;
    //tweek the global volume by moving the slider in the game develpment mode
    [SerializeField] Slider volumeSlider;
    //list of sound to be played one after another
    public Sound[] listOfSounds;

    
    private bool[] isDialogueAlreadyTriggered;
    void Awake()
    {
        //Debug.Log("Currect scene index: " + scene.buildIndex);
        if (SceneManager.GetActiveScene().name == "Menu")
            musicFadeOutSpeed = 0.000f;
        else if (SceneManager.GetActiveScene().name == "Quote")
            musicFadeOutSpeed = 0.001f;
        else
            musicFadeOutSpeed = 0.005f;
        foreach (Sound sound in listOfSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
        // setting the sound volume
        if (PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
        //playing AbelKorzeniowski in Menu
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PlaySound(listOfSounds[0]);
        }
        // playing airConditioner sound in the theatre
        if (SceneManager.GetActiveScene().name == "Theatre")
        {
            PlaySound(listOfSounds[1]);
            dialogueTriggersCount = mainCharacter.GetComponent<DialoguesController>().dialogueSoundTriggers.Length;
            isDialogueAlreadyTriggered = new bool[dialogueTriggersCount];
        }
        
        if (SceneManager.GetActiveScene().name == "Town")
        {
            PlaySound(listOfSounds[0]);
            dialogueTriggersCount = mainCharacter.GetComponent<DialoguesController>().dialogueSoundTriggers.Length;
            isDialogueAlreadyTriggered = new bool[dialogueTriggersCount];
        }
    }
    private void Start()
    {
    }

    private void Update()
    {
        if (mainCharacter != null)
        {
            foreach (int i in Enumerable.Range(0, dialogueTriggersCount))
            {
                //setting the dialogueRequestState variable with the value of the sound trigger from the main character object
                bool dialogueRequestState = mainCharacter.GetComponent<DialoguesController>().dialogueSoundTriggers[i];
                if (dialogueRequestState == true && isDialogueAlreadyTriggered[i] == false){
                    Debug.Log("Playing dialogue #" +  (i+2) + ", " + dialogueRequestState + ", " + isDialogueAlreadyTriggered[i] );
                    isDialogueAlreadyTriggered[i] = true;
                    if (SceneManager.GetActiveScene().name == "Town")
                        StartCoroutine(PlaySoundFromIndex(i + 3));
                    if (SceneManager.GetActiveScene().name == "Theatre") 
                        StartCoroutine(PlaySoundFromIndex(i+2));
                }
            }
            //fading the global sound out
            if (isNextLevelLoading)
            {
                foreach (Sound sound in listOfSounds)
                {
                    //sound.source.volume -= musicFadeOutSpeed;
                    sound.source.volume -= (sound.source.volume / 100);
                }
            }
            if (SceneManager.GetActiveScene().name == "Theatre")
            {
                //fading the AirConditioner sound out
                if (mainCharacter.GetComponent<OnTriggerPlaySound>().shouldMorningMoodBePlayed == true && listOfSounds[1].volume != 0f)
                {
                    mainCharacter.GetComponent<OnTriggerPlaySound>().shouldMorningMoodBePlayed = false;
                    StartCoroutine(PlayMorningMoodCoroutine());
                }
                //fading the MornignMood sound out
                if (mainCharacter.GetComponent<DialoguesController>().shouldBeMusicTurnedDown == true && listOfSounds[0].volume != 0f)
                {
                    listOfSounds[0].source.volume -= 0.0003f;
                }
            }
        }
    }

    //playing a sound by selected index
    IEnumerator PlaySoundFromIndex (int index)
    {
            PlaySound(listOfSounds[index]);
            yield return new WaitForSeconds(1);
    }

    //evoking built-in Play() method
    public void PlaySound(Sound sound)
    {
        sound.source.Play();
        
    }
    IEnumerator PlayMorningMoodCoroutine()
    {
        yield return new WaitForSeconds(10);
        PlaySound(listOfSounds[0]);
        //how much time of waiting from collision to the MorningMood playing
        foreach (int i in Enumerable.Range(0, 10))
        {
            listOfSounds[1].source.volume = listOfSounds[1].source.volume / 1.2f;
        }
    }
    // tweak the sound volume in the game settings
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    //loading the sound volume from the saved settings
    private void LoadVolume()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    //saving the sound volume to the settings
    private void SaveVolume()
    {
        if (volumeSlider != null)
        {
            PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        }
    }
}
