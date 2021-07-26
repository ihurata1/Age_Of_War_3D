using System.Collections;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public bool spawner = true;
    public GameObject[] enemyCharacters;
    int selectedCharacter = 0;
    Vector3 centerPoint;
    float sizeX, sizeZ;
    public float spawnDelay;

    void Start()
    {
        enemyCharacters = GameManager.Instance().allCharacters;
        GameObject zone = GameObject.FindGameObjectWithTag("EnemyZone");
        centerPoint = zone.transform.position;
        sizeX = zone.transform.lossyScale.x;
        sizeZ = zone.transform.lossyScale.z;
        StartCoroutine(SpawnEnemy());

    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        float randomX = UnityEngine.Random.Range(-sizeX / 2, sizeX / 2);
        float randomZ = UnityEngine.Random.Range(-sizeZ / 2, sizeZ / 2);
        Vector3 randomSpawnPoint = centerPoint + (new Vector3(randomX, 0, randomZ));


        if (spawner)
        {

            selectedCharacter = getCharacterIndex();//Temporary Code For Seeing All the Characters
            Spawner.SpawnCharacter(enemyCharacters[selectedCharacter], randomSpawnPoint, Directions.PlayerBuilding);

        }
        StartCoroutine(SpawnEnemy());

    }
    private int getCharacterIndex()
    {
        float oran = timeConvertToSeconds(GameTimer.curTime) / timeConvertToSeconds(GameTimer.totalTime);
        if (oran < 0.25)
        {
            int rand = UnityEngine.Random.Range(0, 100);
            if (rand < 0)
                return 2;
            if (rand <= 25)
                return 1;
            return 0;
        }
        else if (oran < 0.50)
        {
            int rand = UnityEngine.Random.Range(0, 100);
            if (rand <= 15)
                return 2;
            if (rand <= 55)
                return 1;
            return 0;
        }
        else{
            return UnityEngine.Random.Range(0, 2);
        }
    }
    private int timeConvertToSeconds(DateTime time)
    {
        return time.Second + (60 * time.Minute);
    }
}
