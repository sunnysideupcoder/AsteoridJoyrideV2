using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject Plane;
    public float spinRate;
    public AudioSource explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        //refering to a specific game object 
        Plane = GameObject.Find("Plane");
        
        
    }

    //rotate asteroids
    void Update()
    {
        explosionAudio.Play();
        transform.Rotate(0, 0, spinRate*Time.deltaTime);

    }




    //destroy plane when it collides with asteroid
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("COLLISION");

        if (otherCollider == Plane.GetComponent<PolygonCollider2D>())
        {
            
            otherCollider.gameObject.SetActive(false);
            
        }
    }



}
