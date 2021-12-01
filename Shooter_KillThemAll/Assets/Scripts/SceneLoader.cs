using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    // Loads the first level - either at start or replay
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // Exits the app - only works for a built version of the app
    public void ExitApplication()
    {
        // Application.Quit(); 
        Debug.Log("You Have Quit The Game!!");
    }


}
