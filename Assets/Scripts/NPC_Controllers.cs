using UnityEngine;
using UnityEngine.AI;

public class NPC_Controllers : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject[] locations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void daMove()
    {
        agent.Move(agent.desiredVelocity * Time.deltaTime);
    }
}
