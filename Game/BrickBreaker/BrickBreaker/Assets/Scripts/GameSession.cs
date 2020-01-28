using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //Config Params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f; //[Range()] creates a slider in the inspector
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText; //This is the Text mesh pro
    [SerializeField] bool isAutoPlayEnabled;

    //State Variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; //Grabs the length of the array of GameSession that were found
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject); //Destroy yourself. Note this is being implemented at the end of the frame cycle so we added a gameObject.SetActive(false)
        }
        else
        {
            DontDestroyOnLoad(gameObject); //The first time this is ran do not destroy this class keep it as is and all its children. gameObject is the object in the unity inspector.
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed; //By increasing the gamespeed we are increasing the movement of the game
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed; //Setting the amount of points to add per blockhit
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
