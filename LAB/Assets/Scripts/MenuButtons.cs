using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Instructions() 
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelA");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    
    public void Menu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
