using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 15f;

    //public Vector3 moveDirection;

    public Rigidbody objectRB;
    
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public void moveObject(Vector3 moveDirection)
    {
        if (objectRB != null)
        {
            objectRB.AddForce(moveDirection * speed * objectRB.mass, ForceMode.Acceleration);

        }
    }

    public void rotateObject(Vector3 moveDirection)
    {
        if (moveDirection.magnitude == 0)
        {
            transform.rotation = transform.rotation;
        }
        else
        {
            Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotationSpeed);
            objectRB.MoveRotation(rotation);
        }
    }
}
