using UnityEngine;

public class enemyMgr : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRange = 9;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefab, generateSpawnPos(), enemyPrefab.transform.rotation);
    }

    Vector3 generateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
