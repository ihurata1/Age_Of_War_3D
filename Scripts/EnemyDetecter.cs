using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyDetecter : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public bool isEnemy;
    public GameObject target;
    List<GameObject> opponents;
    NavMeshAgent agent;
    private float originalStoppingDistance;
    private void Start()
    {
        if (gameObject.tag == "EnemyCharacter")
        {
            isEnemy = true;
        }
        else if (gameObject.tag == "PlayerCharacter")
        {
            isEnemy = false;
        }
        else
        {
            Debug.LogError("Error 152457");
        }
        agent = gameObject.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.stoppingDistance = attackRadius - 0.17f;
            //originalStoppingDistance = agent.stoppingDistance;
        }

        SetOpponentList();
        StartDetecting();
    }
    public void StartDetecting()
    {
        if (!IsInvoking("UpdateTarget"))
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    public void StopDetecting()
    {
        if (IsInvoking("UpdateTarget"))
            CancelInvoke("UpdateTarget");
    }
    private void UpdateTarget()
    {
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = gameObject.transform.position;
        foreach (GameObject character in opponents)
        {
            var distance = DistanceHelper.SqrMagnitude(gameObject, character);//Vector3.Distance(currentPosition, character.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = character;
            }
        }
        if (nearestEnemy != null && (DistanceHelper.Distance(gameObject, nearestEnemy)) <= lookRadius)
        {
            target = nearestEnemy;

        }
        else
        {
            target = isEnemy ? GameManager.playerBuilding : GameManager.enemyBuilding;
        }

    }
    public bool IsBuilding(GameObject obj)
    {
        return (obj.tag == "PlayerBuilding" || obj.tag == "EnemyBuilding");

    }
    void SetOpponentList()
    {
        if (isEnemy)
        {
            opponents = GameManager.playerCharacters;
        }
        else
        {
            opponents = GameManager.enemyCharacters;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);


        /* Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position,DistanceHelper.Distance(gameObject,target)); */
    }
}
