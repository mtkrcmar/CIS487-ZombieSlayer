using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry2 : MonoBehaviour
{
    public GameObject Journal;
    public GameObject pauseGame;
    public GameObject ResumeText;
    GameObject crosshair;

    // Use this for initialization
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        hideJournal();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();

            if (player)
            {
                pauseGame.GetComponent<PauseScript>().journalActive = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                pauseGame.GetComponent<PauseScript>().paused = true;
                crosshair.SetActive(false);
                Journal.SetActive(true);
                ResumeText.SetActive(true);
            }
        }
    }

    public void hideJournal()
    {
        crosshair.SetActive(true);
        Journal.SetActive(false);
        ResumeText.SetActive(false);
    }
}
