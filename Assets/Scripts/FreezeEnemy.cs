using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreezeEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy entered freeze trigger");
            StartCoroutine(FreezeEnemyComponent(other.gameObject));
        }
    }

    IEnumerator FreezeEnemyComponent(GameObject enemy)
    {
        // Disable the Enemy component
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.enabled = false;

            // Disable the NavMeshAgent component
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            if (agent != null)
                agent.enabled = false;

            // Wait for 2 seconds
            yield return new WaitForSeconds(2f);

            // Enable the Enemy component after 2 seconds
            enemyComponent.enabled = true;

            // Enable the NavMeshAgent component after 2 seconds
            if (agent != null)
                agent.enabled = true;
        }
        else
        {
            Debug.LogWarning("Enemy component not found!");
        }
        Destroy(gameObject);
    }
}
