using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //This is if the ball heads off the screen
    {
        if(collision.gameObject.name == "Ball")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
