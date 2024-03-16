using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    //private GameObject go = GameObject.Find("RainPrefab");
    //RainScript cs = go.GetComponent<RainScript>();
    //public RainScript rain;
    public AudioManager audioManager;
    public Slider slider;
    public Animator transition;
    float currentVelocity = 0;
    public TMP_Text progressText;

    public void Awake()
    {
        //float rainIntensity = rain.GetComponent<RainScript>().rainIntensity;
        //audioManager = GameObject.FindObjectOfType<AudioManager>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayGameWithProgressBar(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void PlayGame(int sceneIndex)
    {
        Debug.Log("Now: fading out display and music");
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void PlayGameWithProgressBar(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronouslyProgressBar(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Debug.Log("Just checking here!");
            audioManager.isNextLevelLoading = true;
        }
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(operation.progress);
            yield return null;
        }
    }

    IEnumerator LoadAsynchronouslyProgressBar(int sceneIndex)
    {
        Debug.Log("It is indeed a Quote level!");
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progress = Mathf.SmoothDamp(slider.value, progress, ref currentVelocity, 100 * Time.deltaTime);

            Debug.Log("Loading scene progress: " + (progress * 100) + "%");
            slider.value = progress;
            progressText.text = (int)((progress/0.9f)*100f) + "%";
            if (progress >= 0.9f)
            {
                Debug.Log("Process is done!");
                break;
            }
            yield return null;
        }
        //audioManager.isNextLevelLoading = true;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        operation.allowSceneActivation = true;

        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        for (int i = 0; i < musicObjects.Length; i++)
        {
            Destroy(musicObjects[i].gameObject);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
