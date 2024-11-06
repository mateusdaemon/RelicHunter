using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickMove : MonoBehaviour
{
    public LayerMask mask;
    RaycastHit hit;
    NavMeshAgent agent;
    PlayerState playerState;
    PlayerAnim playerAnim;

    private void Start()
    {
        
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerState = GetComponent<PlayerState>();
        playerAnim = GetComponent<PlayerAnim>();

        playerState.OnStateChange += playerAnim.SetAnim;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask))
            {
                agent.destination = hit.point;
                playerState.ChangeState(State.Run);
                RotateTowards(hit.point);
            }           
        }

        if (Vector3.Distance(transform.position, hit.point) < 0.5f)
        {
            playerState.ChangeState(State.Idle);
        }
    }

    private void RotateTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * agent.angularSpeed);
        }
    }
}

