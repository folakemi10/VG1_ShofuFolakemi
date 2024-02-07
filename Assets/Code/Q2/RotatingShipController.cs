using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Q2 { 
public class RotatingShipController : MonoBehaviour
{

    //Outlets
    Rigidbody2D _rb;

    //Configurations
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
         _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            //Turn Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _rb.AddTorque(rotationSpeed * Time.deltaTime);

            }

            //Turn Right
            if(Input.GetKey(KeyCode.RightArrow))
            {
                _rb.AddTorque(-rotationSpeed * Time.deltaTime); 
            }

            //Thrust Forward
            if(Input.GetKey(KeyCode.UpArrow))
            {
                //Use right as "forward" because our art faces to the right
                _rb.AddRelativeForce(speed * Time.deltaTime * Vector2.right);
            }
    }
}
}