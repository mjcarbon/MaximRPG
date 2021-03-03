using UnityEngine;
using UnityEngine.AI; // MODULE WE NEED FOR NAVMESH AGENT 

[RequireComponent(typeof(NavMeshAgent))] // WE NEED TO REQUIRE A NAV MESH AGENT 
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent; // NAV MESH AGENT VARIABLE 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void MoveToPoint (Vector3 point) 
    {
        agent.SetDestination(point);
    }
}
