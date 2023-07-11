using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
            
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis(NameManager.HORIZONTAL_INPUT) * -1;

        transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
