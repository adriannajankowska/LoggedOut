using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DialoguesController : MonoBehaviour
{
    // for controlling the visual effects
    public GameObject endCanvasWhite;
    public GameObject endCanvasBlack;
    public Volume postProcessVolume;

    //for controlling the sound
    public bool shouldBeMusicTurnedDown = false;
    public bool[] dialogueSoundTriggers;

    //for controlling the dialogues list
    [SerializeField]
    public GameObject[] dialogueTexts;
    public int[] textDisplayTime;
    public bool[] wasTextAlreadyDisplayed;
    public GameObject dialoguesUI;
    private int textCounter;
    public bool areOpeningDialoguesFinished;
    public bool canDisplayNewText;
    private string sceneName;


    void Start()
    {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        textCounter = 0;
        areOpeningDialoguesFinished = false;
        if (sceneName == "Town")
        {
            StartCoroutine(StartDialoguesTown());
        }
        else if(sceneName == "Theatre")
        {
            StartCoroutine(StartDialoguesTheatre());
        }
    }


    IEnumerator StartDialoguesTown()
    {
        canDisplayNewText = false;
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 3; i++)
        {
            dialogueSoundTriggers[textCounter] = true;
            dialoguesUI.GetComponent<Image>().enabled = true;
            dialogueTexts[textCounter].SetActive(true); 
            yield return new WaitForSeconds(textDisplayTime[textCounter]);
            dialogueTexts[textCounter].SetActive(false);
            dialoguesUI.GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(1f);
            wasTextAlreadyDisplayed[textCounter] = true;
            textCounter += 1;
        }
        areOpeningDialoguesFinished = true;
        canDisplayNewText = true;
    }

    IEnumerator StartDialoguesTheatre()
    {
        canDisplayNewText = false;
        wasTextAlreadyDisplayed[textCounter] = true;
        yield return new WaitForSeconds(4f);
        dialogueSoundTriggers[0] = true; //Whoa, if I'd only known...
        dialoguesUI.GetComponent<Image>().enabled = true;
        dialogueTexts[textCounter].SetActive(true);
        yield return new WaitForSeconds(textDisplayTime[textCounter]);
        dialogueTexts[textCounter].SetActive(false);
        dialoguesUI.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(1f);
        textCounter += 1;
        areOpeningDialoguesFinished = true;
        canDisplayNewText = true;
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "GriegTrigger")
        {
            StartCoroutine(DisplaySelectedDialogue(1));
        }
        if (collider.tag == "OutOfLight")
        {
            StartCoroutine(DisplaySelectedDialogue(3));
        }
        else if (collider.tag == "SmokeCreature")
        {
            StartCoroutine(DisplaySelectedDialogue(4));
        }
        else if (collider.tag == "EmptyThatre")
        {
            StartCoroutine(DisplaySelectedDialogue(5));
        }
        else if (collider.tag == "Enlightment")
        {
            StartCoroutine(DisplaySelectedDialogue(10));
        }
        else if (collider.tag == "Clue")
        {
            StartCoroutine(DisplaySelectedDialogue(7));
        }
        else if (collider.tag == "ShopExposition")
        {
            StartCoroutine(DisplaySelectedDialogue(8));
        }
        else if (collider.tag == "ShowTonight")
        {
            StartCoroutine(DisplaySelectedDialogue(9));
        }
        else if (collider.tag == "PhoneOnTheGround")
        {
            StartCoroutine(DisplaySelectedDialogue(6));
        }

    }

    IEnumerator DisplaySelectedDialogue(int dialogueIndex)
    {
        if (wasTextAlreadyDisplayed[dialogueIndex] == false && areOpeningDialoguesFinished && canDisplayNewText)
        {
            if (dialogueIndex == 4 && sceneName == "Town")
            {
                canDisplayNewText = false;
                //what is that
                wasTextAlreadyDisplayed[dialogueIndex] = true;
                dialogueSoundTriggers[dialogueIndex] = true;
                textCounter += 1;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex]);
                dialogueTexts[dialogueIndex].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(0.5f);
                //look like a sheet of paper
                wasTextAlreadyDisplayed[dialogueIndex+1] = true;
                dialogueSoundTriggers[dialogueIndex+1] = true;
                textCounter += 1;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex+1].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex+1]);
                dialogueTexts[dialogueIndex+1].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(1f);
                //phone zombie
                wasTextAlreadyDisplayed[dialogueIndex+2] = true;
                dialogueSoundTriggers[dialogueIndex+2] = true;
                textCounter += 1;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex + 2].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex + 1]);
                dialogueTexts[dialogueIndex + 2].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(1f);
                canDisplayNewText = true;
            }
            else if(dialogueIndex == 1 && sceneName == "Theatre")
            {
                canDisplayNewText = false;
                //Wow, unbelievable
                wasTextAlreadyDisplayed[dialogueIndex] = true;
                textCounter += 1;
                dialogueSoundTriggers[dialogueIndex] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex]);
                dialogueTexts[dialogueIndex].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(2f);
                //just a gramophone on the stage
                wasTextAlreadyDisplayed[dialogueIndex + 1] = true;
                textCounter += 1;
                dialogueSoundTriggers[dialogueIndex + 1] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex + 1].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex + 1]);
                dialogueTexts[dialogueIndex + 1].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(2.5f);
                //and it started playing
                wasTextAlreadyDisplayed[dialogueIndex+2] = true;
                textCounter += 1;
                dialogueSoundTriggers[dialogueIndex + 2] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex + 2].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex + 2]);
                dialogueTexts[dialogueIndex + 2].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(2f);
                //let's search for some doors
                wasTextAlreadyDisplayed[dialogueIndex + 3] = true;
                textCounter += 1;
                dialogueSoundTriggers[dialogueIndex + 3] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex + 3].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex + 3]);
                dialogueTexts[dialogueIndex + 3].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(1f);
                canDisplayNewText = true;
            }
            else if(dialogueIndex == 6 && sceneName == "Theatre")
            {
                canDisplayNewText = false;
                //smartphone on the stage
                //yield return new WaitForSeconds(2f);
                wasTextAlreadyDisplayed[dialogueIndex] = true;
                textCounter += 1;
                dialogueSoundTriggers[dialogueIndex] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex]);
                dialogueTexts[dialogueIndex].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(5f);
                //one of them
                wasTextAlreadyDisplayed[dialogueIndex + 1] = true;
                textCounter += 1;
                yield return new WaitForSeconds(2f);
                dialogueSoundTriggers[dialogueIndex + 1] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex + 1].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex + 1]);
                dialogueTexts[dialogueIndex + 1].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(1f);
                //time for enlightment
                wasTextAlreadyDisplayed[dialogueIndex + 2] = true;
                textCounter += 1;
                dialogueSoundTriggers[dialogueIndex + 2] = true;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex + 2].SetActive(true);
                yield return new WaitForSeconds(2f);
                dialogueTexts[dialogueIndex + 2].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;

                Bloom bloom;
                var colWhite = endCanvasWhite.GetComponent<Image>().color;
                var colBlack = endCanvasBlack.GetComponent<Image>().color;
                if (postProcessVolume.profile.TryGet<Bloom>(out bloom))
                {
                    for (int i = 0; i < 30; i++)
                    {
                        //Debug.Log("Bloom - " + i);
                        bloom.intensity.value += 2.5f;
                        bloom.scatter.value += 0.0093f;
                        bloom.threshold.value -= 0.0587f;
                        yield return new WaitForSeconds(0.05f);
                    }
                    shouldBeMusicTurnedDown = true;
                    for (int i = 0; i < 150; i++)
                    {
                        Debug.Log("Brightening - " + i);
                        colWhite.a += 0.001f;
                        endCanvasWhite.GetComponent<Image>().color = colWhite;
                        yield return new WaitForSeconds(0.01f);
                    }
                    yield return new WaitForSeconds(2f);
                    for (int i = 0; i < 300; i++)
                    {
                        Debug.Log("Darkening - " + i);
                        colBlack.a += 0.005f;
                        endCanvasBlack.GetComponent<Image>().color = colBlack;
                        yield return new WaitForSeconds(0.001f);
                    }
                    Debug.Log("Shutting down...");
                    Application.Quit();
                }
            }
            else
            {
                canDisplayNewText = false;
                wasTextAlreadyDisplayed[dialogueIndex] = true;
                dialogueSoundTriggers[dialogueIndex] = true;
                textCounter += 1;
                dialoguesUI.GetComponent<Image>().enabled = true;
                dialogueTexts[dialogueIndex].SetActive(true);
                yield return new WaitForSeconds(textDisplayTime[dialogueIndex]);
                dialogueTexts[dialogueIndex].SetActive(false);
                dialoguesUI.GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(1f);
                canDisplayNewText = true;
            }
        }
    }
}
