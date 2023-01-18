using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] public float minSpeed = 5.0f;
    [SerializeField] public float maxSpeed = 25.0f;
    public float speed;
    [SerializeField] public float rotationSpeed;
    public VariableJoystick joystick;
    public Rigidbody rb;

    public GameObject propeller;
    public float propellerRotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        propeller.transform.Rotate(0, 0, propellerRotationSpeed);
        if (joystick == null)
            return;

        if (rb == null)
            return;

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        transform.position += transform.forward * speed * Time.deltaTime;
        Vector2 direction = joystick.Direction;

        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        //x -> kanat
        //y -> uçak yönü 
        //z -> aþaðý yukarý 

        if (movementVector.magnitude != 0)
        {
            //transform.forward = movementVector;
            
            if (vertical > 0.2f)
            {
                //sol kanat aþaðý
                //yön sol
                transform.Rotate(-Time.deltaTime * rotationSpeed, 0, 0);

                //transform.Rotate(0, Time.deltaTime * (rotationSpeed / 2), Time.deltaTime * rotationSpeed, 0f);
            }

            if (vertical < -0.2f)
            {
                transform.Rotate(Time.deltaTime * rotationSpeed, 0, 0);

                //y ve z arttýr
                //transform.Rotate(0, Time.deltaTime * (rotationSpeed / 2), Time.deltaTime * rotationSpeed, 0f);
            }
            
            if (horizontal > 0.2f)
            {
                transform.Rotate(0, -Time.deltaTime * (rotationSpeed / 2), -Time.deltaTime * rotationSpeed, 0f);
            }
            
            if (horizontal < -0.2f)
            {
                transform.Rotate(0, Time.deltaTime * (rotationSpeed / 2), Time.deltaTime * rotationSpeed, 0f);
            }
        }


        Debug.Log(speed);
    }
}
