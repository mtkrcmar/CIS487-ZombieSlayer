using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject crosshair;
    public GameObject journalEntry;
    public GameObject journalEntry2;

    public bool paused = false;
    public bool journalActive = false;
    public bool journalActive2 = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //Uses the escape key to pause and resume the game
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene("InsideHospital");
    }

    //Quits the Level
    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }

    //Controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        crosshair.SetActive(false);
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
        Cursor.visible = true;
        paused = true;
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        crosshair.SetActive(true);
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }

        if (journalActive == true)
        {
            journalActive = false;
            journalEntry.GetComponent<JournalEntry>().hideJournal();
            Destroy(journalEntry);
        }

        if (journalActive2 == true)
        {
            journalActive2 = false;
            journalEntry2.GetComponent<JournalEntry2>().hideJournal();
            Destroy(journalEntry2);
        }

        Cursor.visible = false;
        paused = false;
    }
}
