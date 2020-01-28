using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minWidth = 1f;
    [SerializeField] float maxWidth = 15f;

    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); //Create a new Vector2 just how we instantiate a class
        paddlePos.x = Mathf.Clamp(GetXPos(), minWidth, maxWidth); //We are using this to assign the X position
        transform.position = paddlePos; //Take the new vector
    }

    private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x; //We are grabbing the balls position every frame
        }
        else
            return Input.mousePosition.x / Screen.width * screenWidthInUnits; //Just want to know the x position of the mouse so we divide it by the Screen.width (1) and then we multiple by 16 since thats how many pixels it is per unit.

    }
}
