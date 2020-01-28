using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Grabs the current scene index
        SceneManager.LoadScene(currentSceneIndex + 1); //Adds 1 to the index to advacne
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0); //Loads the first scene
        var gameStatus = FindObjectOfType<GameSession>();
        gameStatus.ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit(); //Quits the application
    }
}
