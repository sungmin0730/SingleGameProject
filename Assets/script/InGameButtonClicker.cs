using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonClicker : MonoBehaviour
{

    public GameObject StopPanel;

    public void OnClickStopButton()
    {
        Time.timeScale = 0f;
        StopPanel.SetActive(true);
    }
    public void OnClickResumeButton()
    {
        Time.timeScale = 1f;
        StopPanel.SetActive(false);
    }
    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("titlescreen");
    }
    public void OnClickExitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
