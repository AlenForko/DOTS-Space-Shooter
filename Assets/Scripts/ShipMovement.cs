using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private float _RotationSpeed = 30f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float rotationAngle = horizontalInput * _RotationSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0, 0, -1) * rotationAngle);
    }
    
}
