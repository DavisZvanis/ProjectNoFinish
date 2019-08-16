using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
 public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationY = Input.GetAxis("Vertical") * speed;

        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
Vector3 realDirection = Camera.main.transform.TransformDirection(movementDirection);
// this line checks whether the player is making inputs.
if(realDirection.magnitude > 0.1f)
{
    Quaternion newRotation = Quaternion.LookRotation(realDirection);
    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
}
        // Make it move 10 meters per second instead of 10 meters per frame...
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(translationX, translationY, 0);
    }
}
