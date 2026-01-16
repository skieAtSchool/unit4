using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 5;
    public GameObject focalPoint;
    public bool hasPowerup = false;
    public float powerUpStrength = 15.0f;
    public GameObject powerupIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("focalPoint");
        powerupIndicator.SetActive(false);
    }
    void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0f, -.5f, 0f);
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
            powerupIndicator.SetActive(true);
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
        powerupIndicator.SetActive(false);
    }

}
