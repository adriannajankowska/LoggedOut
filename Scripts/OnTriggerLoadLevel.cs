using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour
{
    public GameObject levelLoader;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "TheatreEntrance")
        {
            levelLoader.GetComponent<LevelLoader>().PlayGame(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
