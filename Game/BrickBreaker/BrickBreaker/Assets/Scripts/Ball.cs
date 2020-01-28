using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1; //We are grabbing a reference to the paddle we have in game
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    [SerializeField] AudioClip[] ballSounds; //We are creating an array of clips

    Vector2 paddleToBallVector; //Grabbing a reference to the location of the paddle
    Rigidbody2D myRigidBody2D;

    AudioSource myAudioSource; //Plays the sounds

    private bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; //Grabbing the position of the ball and subtracting from the paddle to get the diff
        myAudioSource = GetComponent<AudioSource>(); //Grab the component
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) //False
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush); //Access the Rigidbody and mass with the velocity. Velocity reacts instantly to the force you put on the object, for example a human jumping will happen fast but as he hits the ground it will be a tad slower. Addforce starts slow but then falls quicker as it takes mass in consideration.
            hasStarted = true; //This will prevent the update to keep playing
        }
    }

    private void LockBallToPaddle() //Gives us the diff plus the paddles location
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); //Creating a new Vector2 that takes in the paddles position
        transform.position = paddlePos + paddleToBallVector; //Add the paddle position and the diff that we calculated
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor)); //Grabs us a random x and y value
        if (hasStarted) //Only play this sound if it has collided and the game has started. Multiple concepts of random we are using two different namespaces so we simply commented our Random classes to see what namespaces we were using and deleted the generic ones.
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)]; //Play a random sounds on collision
            myAudioSource.PlayOneShot(clip); //PlayOneShot plays the entire clip of the audio clip
            myRigidBody2D.velocity += velocityTweak; //Adds a velocity to its current path
        }
    }
}
