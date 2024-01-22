using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaneMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float planeSpeed;
    public float steerSens;
    public GameObject logic;
    public float playerSens;
    public bool escape;
    private GameOverScript GameOver;
    public int BounceOffAngle;
    public float consFowardSpeed;




    private Controls PlayerControls;
    private void Awake()
    {
        PlayerControls = new Controls();
        

    }

    private void OnEnable()
    {
        PlayerControls.Enable();
       
    }

    private void OnDisable()
    {
        PlayerControls.Disable();

    }


    // Start is called before the first frame update
    void Start()
    {

        LogicScript logicScript = logic.GetComponent<LogicScript>();

        playerSens = logicScript.sens;

        



    }

    // Update is called once per frame
    void Update()
    {
        // declare variables that take in player inputs
        float linear = PlayerControls.Plane.LinearMove.ReadValue<float>();
        float steer = PlayerControls.Plane.Steer.ReadValue<float>();

        //bool escape = PlayerControls.Plane.Escape.ReadValue<bool>();



        // this rotates the car on its own axis (turns car left and right)
        // The if statement keeps the plane from being able to go backwards away from the action
        

        
        

        if ((rb.rotation >= 90 && steer == 1) || (rb.rotation <= -90 && steer == -1))
        {
            //Debug.Log("Cant steer that Far!!!");
        }

        else
        {
            
            float zDegrees = steer * steerSens*Time.deltaTime*playerSens;
            transform.Rotate(0, 0, zDegrees);

        }


        //Code to adjust velocity of our rigid body, basically allows plane to move foward in the direction its facing when player presses W


        float rotation = rb.rotation* Mathf.Deg2Rad; // unity returns rotation in degrees so we must convert to radians

        float yVelocity = linear * math.sin(rotation) * planeSpeed*Time.deltaTime;
        

        float xVelocity = linear * math.cos(rotation) * planeSpeed * Time.deltaTime;

        // if else is to create invisible barrier at top and bottom, 
        //if part normal movement within the boundaries
        if (math.abs(transform.position.y) < 19.0)

        transform.position = transform.position + new Vector3(xVelocity, yVelocity, 0);

        else
        {
            if(transform.position.y < 0)
            {
                transform.position = transform.position + new Vector3(+math.abs(xVelocity), +math.abs(yVelocity), 0);
            }
            else
            {
                transform.position = transform.position + new Vector3(+math.abs(xVelocity), -math.abs(yVelocity), 0);
            }
        

        }

        transform.position = transform.position + new Vector3(consFowardSpeed*math.abs(math.sin(rotation)),0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameOver = GameObject.Find("GameOverScreen").GetComponent<GameOverScript>();
        GameOver.GameRestart();
        Debug.Log("gameRestart called");

        
        
        
    }

    //function to make plane horizontal and then rotate slightly to center   
    public void align() { 
    
        transform.rotation = Quaternion.identity;

        int rotation = 5;
        if (transform.position.y > 0)
        {
            this.transform.Rotate(0, 0, -rotation);
        }
        else
        {
            this.transform.Rotate(0,0,rotation);
        }
        
    }

    //temporarely takes 
    public void straightPlane()
    {
        if (transform.position.y > 0)
        {
            BounceOffAngle *= -1;
        }
        transform.rotation = Quaternion.Euler(0, 0, BounceOffAngle);
        transform.position = transform.position + new Vector3(0, 0, 0);
    }
}
