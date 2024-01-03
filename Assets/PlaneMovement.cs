using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlaneMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 rotation;
    
        
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

    }

    // Update is called once per frame
    void Update()
    {
        float linear = PlayerControls.Plane.LinearMove.ReadValue<float>();
        float steer = PlayerControls.Plane.Steer.ReadValue<float>();

        float zDegrees = steer*0.5F;

        float Force = linear * 0.05F;

        float test = PlayerControls.Plane.Testing.ReadValue<float>();

        Vector2 position = this.transform.position; //this. optional

        Debug.Log("linear " + linear);
        Debug.Log("Steer " + steer);
        Debug.Log("Testing " +  test);

        
        velocity = new Vector3(linear, steer,0);

        //
        this.transform.Rotate(0 , 0 , zDegrees);

        float planeSpeed = 10;

        float rotation = rb.rotation* Mathf.Deg2Rad; // unity returns rotation in degrees so we must convert to radians

        float yVelocity = linear * math.sin(rotation) * planeSpeed;

        float xVelocity = linear * math.cos(rotation) * planeSpeed;

        rb.velocity = new Vector2(xVelocity, yVelocity;

        
        


        

      
        

        //Debug.Log("rb velocity x: " + rb.velocity.x + ", " + "rb velocty: " +  rb.velocity.y);
        

        

        //rb.AddForce(new Vector2 (Force, 0));  // using w and s to apply a linear force
        //Debug.Log(rb.totalForce.x);

        

        //this.transform.position = this.transform.position + velocity;
        
        
        
    }
}
