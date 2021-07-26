using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static void SpawnCharacter(GameObject character, Vector3 spawnPoint, Directions direction)
    {
        if (direction == Directions.EnemyBuilding && !GoldManager.SpendGold(character.GetComponent<Character>().price))
            return;
        Vector3 realSpawnPoint = new Vector3(spawnPoint.x, character.transform.position.y, spawnPoint.z);
        GameObject createdCharacter = Instantiate(character);
        createdCharacter.transform.position = realSpawnPoint;
        if (direction == Directions.PlayerBuilding)
        {
            createdCharacter.transform.Rotate(0, 180, 0);
            createdCharacter.tag = "EnemyCharacter";
            GameManager.enemyCharacters.Add(createdCharacter);
        }
        else
        {
            createdCharacter.tag = "PlayerCharacter";
            GameManager.playerCharacters.Add(createdCharacter);
        }
        createdCharacter.SetActive(true);

    }
    public static GameObject SpawnTurret(GameObject turret, Vector3 spawnPoint, Directions direction)
    {
        if (!GoldManager.SpendGold(turret.GetComponent<Turret>().price))
            return null;
        Vector3 realSpawnPoint = new Vector3(spawnPoint.x, turret.transform.position.y, spawnPoint.z);
        GameObject createdTurret = Instantiate(turret);
        createdTurret.transform.position = realSpawnPoint;
        if (direction == Directions.PlayerBuilding)
        {
            createdTurret.transform.Rotate(0, 180, 0);
            createdTurret.tag = "EnemyCharacter";
        }
        else
        {
            createdTurret.tag = "PlayerCharacter";
        }
        createdTurret.SetActive(true);
        return createdTurret;
    }
}
