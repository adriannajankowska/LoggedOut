using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float pollingTime = 1f;
    private float time;
    private int frameCount;
    public Button checkedButton;
    public Button uncheckedButton;

    void Start()
    {
        Button btnChecked = checkedButton.GetComponent<Button>();
        Button btnUnchecked = uncheckedButton.GetComponent<Button>();
        btnChecked.onClick.AddListener(TaskOnClickOnChecked);
        btnUnchecked.onClick.AddListener(TaskOnClickOnUnchecked);
    }
    void TaskOnClickOnChecked()
    {
        fpsText.enabled = false;
    }
    void TaskOnClickOnUnchecked()
    {
        fpsText.enabled = true;
    }
    void Update()
    {
        if (fpsText.enabled == true)
        {
            time += Time.deltaTime;
            frameCount++;
            if (time >= pollingTime)
            {
                int frameRate = Mathf.RoundToInt(frameCount / time);
                fpsText.text = frameRate.ToString() + " FPS";
                time -= pollingTime;
                frameCount = 0;
            }
        }
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
