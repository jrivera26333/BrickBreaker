using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    //Cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>(); //Grabs a reference of this class
    }

    public void CountBlocks() //We are using this method to count the blocks are destroyed
    {
        breakableBlocks++;
    }

    public void BlockDestroyed() //this will count the blocks destroyed and then play the next scene when we are at 0
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene(); //Load next level
        }
    }
}
