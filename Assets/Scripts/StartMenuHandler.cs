using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour {

    public GameObject HowToPlayPanel;
    public GameObject ControlsPanel;

    // Use this for initialization
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }   

    public void OpenHowToPlay()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void OpenControls()
    {
        ControlsPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        HowToPlayPanel.SetActive(false);
    }

    public void CloseControls()
    {
        ControlsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
