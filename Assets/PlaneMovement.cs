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
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 rotation;
    public bool alive;
    public int counter;
    public GameObject logic;
    public float playerSens;
    public bool escape;

    private GameOverScript GameOver;
    
    
        
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
        //rb = gameObject.GetComponent<Rigidbody2D>();
        alive = true;
        counter = 0;

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

        // CHATGPT code to convert float value to bool 
        float escapeValue = PlayerControls.Plane.Escape.ReadValue<float>();
        bool escape = Mathf.Approximately(escapeValue, 1.0f);

        //control escape key
        if (escape)
        { 
            SceneManager.LoadScene("Main Menu");
        }

        // this rotates the car on its own axis (turns car left and right)
        // The if statement keeps the plane from being able to go backwards away from the action
        counter++;

        
        

        if ((rb.rotation >= 90 && steer == 1) || (rb.rotation <= -90 && steer == -1))
        {
            //Debug.Log("Cant steer that Far!!!");
        }

        else
        {
            //original steersens was 0.8
            float zDegrees = steer * steerSens*Time.deltaTime*playerSens;
            this.transform.Rotate(0, 0, zDegrees);

        }


        //Code to adjust velocity of our rigid body, basically allows plane to move foward in the direction its facing when player presses W

        //float planeSpeed = 10; 

        float rotation = rb.rotation* Mathf.Deg2Rad; // unity returns rotation in degrees so we must convert to radians

        float yVelocity = linear * math.sin(rotation) * planeSpeed*Time.deltaTime;
        Debug.Log("cos roatation " + math.cos(rotation));

        float xVelocity = linear * math.cos(rotation) * planeSpeed * Time.deltaTime;

        rb.velocity = new Vector2(xVelocity, yVelocity);

        //linear speed before time delta time was 30

        

        //obj.transform.position = obj.transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
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
}
