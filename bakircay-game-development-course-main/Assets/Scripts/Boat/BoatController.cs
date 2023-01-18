using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public VariableJoystick joystick;
    public float Speed = 5f;
    public float RotationSpeed = 10f;

    void Update()
    {
        if (joystick == null)
            return;


        Vector2 direction = joystick.Direction;
        
        //nesnenin hangi yönlerde hareket edeceðini belirliyor 
        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        movementVector = movementVector * Time.deltaTime * Speed;

        transform.position += movementVector;

        float rotation = direction.x * RotationSpeed * Time.deltaTime;

        // Rotate the object
        if (movementVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
        }

 

    }

    //private void FixedUpdate()
    //{
    //    if (movementCache != Vector3.zero)
    //    {
    //        transform.position += movementCache;
    //        movementCache = Vector3.zero;  
    //    }

    //}
}
