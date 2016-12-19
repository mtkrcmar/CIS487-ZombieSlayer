using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry2 : MonoBehaviour
{
    GameObject[] journalObjects;
    GameObject crosshair;
    public GameObject pauseGame;

    // Use this for initialization
    void Start()
    {
        journalObjects = GameObject.FindGameObjectsWithTag("JournalPickup2");
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
                pauseGame.GetComponent<PauseScript>().journalActive2 = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                pauseGame.GetComponent<PauseScript>().paused = true;
                crosshair.SetActive(false);
                foreach (GameObject g in journalObjects)
                {
                    g.SetActive(true);
                }
            }
        }
    }

    public void hideJournal()
    {
        crosshair.SetActive(true);
        foreach (GameObject g in journalObjects)
        {
            g.SetActive(false);
        }
    }
}
