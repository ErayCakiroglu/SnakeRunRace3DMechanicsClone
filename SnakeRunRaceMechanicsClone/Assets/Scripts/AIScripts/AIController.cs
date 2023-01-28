using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AIController : MonoBehaviour
{
    /*It is a class structure that assigns a random number of gems to enemy game objects, allowing them to advance to the target sent to them.*/
    public int enemyGemCount;
    private NavMeshAgent enemyNavMeshAgent;
    private TextMeshPro gemCountText;
    private GameObject target;
    void Start()
    {
        target = GameObject.Find("End");
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        gemCountText = GetComponent<TextMeshPro>();
        enemyGemCount = Random.Range(10, 45);
        gemCountText.text = enemyGemCount.ToString();
    }
    void Update()
    {
        enemyNavMeshAgent.SetDestination(target.transform.position);
    }
}
