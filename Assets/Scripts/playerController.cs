using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 5;
    public GameObject focalPoint;
    public bool hasPowerup;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hasPowerup)
        {
            Debug.Log("Have powerup and collided with " + collision.gameObject.name);
        }
    }
}
