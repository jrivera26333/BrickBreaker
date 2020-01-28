using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkles; //Its part of a gameObject
    [SerializeField] Sprite[] hitSprites;


    //Cached reference
    Level level;
    GameSession gamestatus;

    //State variables
    [SerializeField] int timesHit; //TODO only serialized for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>(); //We are looking of a particular thing of type Level. Getting a reference NOT instantiation!

        if (tag == "Breakable") //If the block this script is attached to is Breakable tally it once and send the info to our level script
        {
            level.CountBlocks(); //This will call this method and increase the value
        }

        gamestatus = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision) //We can take away this parameter. If we have any collision destroy this gameObjects
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1; //Rather then setup the max hits it will go off of the size of the arry we assign. The length starts at 0 so we add +1.
        if (timesHit >= maxHits)
            DestroyBlock();
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit -1; //timesHit starts at one by the time this is ran
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Error block sprite is missing from array!" + gameObject.name.ToString());
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position); //We are referencing the camera since thats where we are listening to the sounds. PlayClipAtPoint makes a one shot audio in the heiarchy that creates an instance of the audio then destroys itself.
        gamestatus.AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
