using UnityEngine;
//no longer in use
// detects when any object collides with 
public class BarricadeScript : MonoBehaviour
{
    private PlaneMovement Plane;
    public int BounceOffAngle;

    private void OnTriggerEnter2D(Collider2D plane)
    {
        Plane = GameObject.Find("Plane").GetComponent<PlaneMovement>();
        //Plane.align(); 
        if (Plane.transform.position.y > 0) {
            BounceOffAngle *= -1;
        }
        Plane.transform.rotation = Quaternion.Euler(0, 0, BounceOffAngle);


    }
}
