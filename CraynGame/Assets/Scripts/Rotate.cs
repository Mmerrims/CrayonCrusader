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
        StartCoroutine(Rotate2());
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

    private IEnumerator Rotate2()
    {
        Vector3 startRotation = RotatedObject.transform.eulerAngles;
        float timer = 0;
        while (timer < rotateSpeed) 
        {
            timer += Time.deltaTime;
            RotatedObject.transform.eulerAngles = Vector3.Lerp(startRotation, new Vector3(startRotation.x, startRotation.y, startRotation.z + 90), timer/rotateSpeed);
            yield return null;
        }
        
    }

}



