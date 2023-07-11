using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody mybody;

    private GameObject focalPoint;

    private void Start()
    {
        mybody = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindWithTag(NameManager.FOCALPOINT_TAG);
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis(NameManager.VERTICAL_INPUT);

        mybody.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime, ForceMode.Impulse); 

    }
}
