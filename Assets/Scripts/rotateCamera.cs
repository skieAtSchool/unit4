using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public float maxSpeed = 5;
    public float acceleration = 5;
    private Vector3 currentVelocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 test = new Vector3(0, horizontalInput * maxSpeed, 0);

        currentVelocity = Vector3.MoveTowards(currentVelocity, test, acceleration * Time.deltaTime);

        transform.Rotate(currentVelocity);
    }
}
