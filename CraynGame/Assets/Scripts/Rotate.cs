using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private GameObject RotatedObject;
    private Rigidbody2D rb;
    [SerializeField] private float rotateSpeed;
    private bool isTurning;

    private void Awake()
    {
        rb = RotatedObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isTurning != false)
        {
            StartRotation();
        }

    }

    public void StartRotation()
    {
        //START WORKING HERE!!!!!
        float NewXRotation = (RotatedObject.transform.rotation.x + rotateSpeed);
        //RotatedObject.transform.rotation = NewXRotation;
        //rb.AddTorque(rotateSpeed * Time.fixedDeltaTime);
    }

    public void IsTurningOnOff()
    {
        if (isTurning == false)
        {
            isTurning = true;
        }
        
        if (isTurning == true)
        {
            isTurning = false;
        }
    }

}



