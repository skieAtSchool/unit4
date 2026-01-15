using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 5;
    public GameObject focalPoint;
    public bool hasPowerup = false;
    public float powerUpStrength = 15.0f;

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
            StartCoroutine(powerUpCountDown());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hasPowerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            Debug.Log("Have powerup and collided with " + collision.gameObject.name);
            enemyRB.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

        }
    }
    IEnumerator powerUpCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }

}
