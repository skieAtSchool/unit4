using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 5;
    public GameObject focalPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("focalPoint");
    }
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
