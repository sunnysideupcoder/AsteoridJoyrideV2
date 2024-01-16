using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject Plane;
    public float spinRate;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //refering to a specific game object 
        Plane = GameObject.Find("Plane");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //makes asteroids spin
        //Time.timeScale = 1.0f;
        //Debug.Log(Time.timeScale);

        //timedetla time to make it frame rate independent
        transform.Rotate(0, 0, spinRate*Time.deltaTime);



        //if (Quaternion.Angle(transform.rotation, Quaternion.identity) < 0.01f)
        //{
        //    count++;
        //}

        //Debug.Log("Rotation  " + transform.rotation + "Identity " + Quaternion.identity + "Angle " + Quaternion.Angle(transform.rotation, Quaternion.identity));

    }




    //destroy plane when it collides with asteroid
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        

        if (otherCollider == Plane.GetComponent<Collider2D>())
        {

            //Debug.Log("Plane Ran into Asteroid");
            //Destroy(otherCollider.gameObject);  //gameObject always refers to the game object that holds this script
            otherCollider.gameObject.SetActive(false);
        }
    }



}
