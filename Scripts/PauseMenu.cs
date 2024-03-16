using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject camera;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(camera.GetComponent<MouseLook>().isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera.GetComponent<MouseLook>().isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.2f;
        isGamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        camera.GetComponent<MouseLook>().isGamePaused = true;
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera.GetComponent<MouseLook>().isGamePaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //camera.GetComponent<MouseLook>().isGamePaused = false;
    }

}
