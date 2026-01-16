using UnityEngine;

public class enemyMgr : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int number = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnWave(number);
    }

    Vector3 generateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void spawnWave(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Debug.Log("spawning #" + i);
            Instantiate(enemyPrefab, generateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
