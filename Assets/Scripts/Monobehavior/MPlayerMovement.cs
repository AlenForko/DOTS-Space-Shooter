using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        transform.Rotate(Vector3.back * (horizontalInput * rotationSpeed * Time.deltaTime));
    }
}
