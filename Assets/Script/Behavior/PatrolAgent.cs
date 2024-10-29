using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAgent : MonoBehaviour
{


    [SerializeField]
    Transform[] targets;
    int targetIndex = -1;

    private NavMeshAgent agentStatus;

    public Action OnComplete;


    private void Start()
    {
        agentStatus = GetComponent<NavMeshAgent>();

        OnComplete += SetTarget;
        SetTarget();

    }

    public void Update()
    {
        if(agentStatus.pathStatus == NavMeshPathStatus.PathComplete && agentStatus.remainingDistance - agentStatus.stoppingDistance < 0.1f)
        { 
            OnComplete.Invoke();

        }


    }

    void SetTarget()
    { 
   
        targetIndex = (targetIndex + 1) % targets.Length;
        agentStatus.SetDestination(targets[targetIndex].position);

    }


}
