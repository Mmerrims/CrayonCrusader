using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private GameObject RotatedObject;
    private Rigidbody2D rb;
    [SerializeField] private float rotateSpeed;
    private bool isTurning;
    [SerializeField] private float timerLength;

    private void Awake()
    {
        rb = RotatedObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(StartGameCountdown());
    }

    private IEnumerator StartGameCountdown()
    {
        yield return new WaitForSeconds(timerLength);
        StartCoroutine(Rotate2());
        StartCoroutine(StartGameCountdown());
        yield return null;
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



