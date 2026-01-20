using UnityEngine;

public class enemyMgr : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNum = 1;
    public GameObject powerupPrefab;

    private void Update()
    {
        enemyCount = FindObjectsByType<enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, generateSpawnPos() + new Vector3(0, 0.5f, 0), powerupPrefab.transform.rotation);
            spawnWave(waveNum);
            waveNum++;
        }
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
