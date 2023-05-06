using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    GameObject[] paused;
    GameObject[] resumed;
    bool isPaused = false;

    void Start()
    {
        paused = GameObject.FindGameObjectsWithTag("Pause");
        resumed = GameObject.FindGameObjectsWithTag("Resume");

        foreach (GameObject g in paused) {
            g.SetActive(false);
        }    
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && isPaused == false) {
            Pause();
            isPaused = true;
        } else if (Input.GetKeyDown("escape") && isPaused == true) {
            Resume();
            isPaused = false;
        }
    }

    public void Pause() 
    {
        Time.timeScale = 0.0f;
        AudioManager.Instance.musicSource.Pause();

        foreach(GameObject g in paused) {
            g.SetActive(true);
        }

        foreach(GameObject g in resumed) {
            g.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        AudioManager.Instance.musicSource.UnPause();
        foreach(GameObject g in paused) {
            g.SetActive(false);
        }

        foreach(GameObject g in resumed) {
             g.SetActive(true);
        }
    }
}
