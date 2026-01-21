using UnityEngine;

public class enemy : MonoBehaviour
{
    private float speed = 1;
    private Rigidbody enemyRb;
    private GameObject player;
    int waveCnt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        waveCnt = SpawnManagerX.waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        Vector3 lookDir = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDir.normalized * speed);
    }
}
