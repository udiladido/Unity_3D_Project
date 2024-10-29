using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIStatus
{ 
    Idle,
    PathComplete,
    Attacking,


}


public class EnemyController : MonoBehaviour
{

    [Header("stats")]
    public int healt;
   


    [Header("AI")]
    public NavMeshAgent agent;




}
