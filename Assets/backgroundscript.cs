using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class backgroundscript : MonoBehaviour
{
    public float scrollSpeed;
    private GameObject Camera;
    private float distanceToCamera;
    public float canvasWidth = 34.5F;
    //34.27 nice
    // Start is called before the first frame update
    void Start()
    {
        
        Camera = GameObject.Find("Main Camera");
        distanceToCamera = transform.position.x - Camera.transform.position.x ;
        Debug.Log(distanceToCamera);
        


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(scrollSpeed, 0, 0);

        if (transform.position.x > Camera.transform.position.x + (canvasWidth*2) + -distanceToCamera) 
        {

            transform.position = new Vector3(Camera.transform.position.x - canvasWidth*2 + -distanceToCamera, 0,0 );

        }
        
    }
}
