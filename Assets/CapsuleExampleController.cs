using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapsuleExampleController : MonoBehaviour
{
    [SerializeField] private List<Transform> goals;
    [SerializeField] private float minDistance;

    private NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = goals[Random.Range(0, goals.Count - 1)].position;
    }

    private void Update()
    {
        
        if (_agent.destination!=null && Vector3.Distance(_agent.destination, transform.position) < minDistance)
        {
            while (true)
            {
                var g = goals[Random.Range(0, goals.Count - 1)].position;
                if (g!=_agent.destination)
                {
                    _agent.destination = g;
                    break;
                }
            }
        }
    }
}
