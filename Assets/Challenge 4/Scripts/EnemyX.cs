using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    public Vector3 lookDirection;
    int waveCnt;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("playerGoal");
        waveCnt = SpawnManagerX.waveCount;
        speed = waveCnt * .5f + 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection.normalized * speed /** Time.deltaTime*/);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
