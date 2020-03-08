using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerFollower : MonoBehaviour
{
  public GameObject player;

  // for calucalting movWayPoint speed
  private Vector3 prevPos;
  private NavMeshAgent navMeshAgent;
  public Vector3 rawVelocity
  {
    get;
    private set;
  }

  public Vector3 velocity
  {
    get;
    private set;
  }
  public float smoothingTimeFactor = 10.5f;
  private Vector3 smoothingParamVel;

  // Start is called before the first frame update
  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
    prevPos = player.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    computeMovWayPointSpeed();
    moveToPlayer();
  }

  private void moveToPlayer()
  {
    float distDiff = Vector3.Distance(player.transform.position, navMeshAgent.transform.position);
    float aiArriveTime = distDiff / navMeshAgent.speed;
    aiArriveTime = Mathf.Clamp(aiArriveTime, 0.0f, 0.4f);
    Vector3 lookAheadDist = (aiArriveTime * velocity);
    //Debug.Log(aiArriveTime);

    navMeshAgent.SetDestination(lookAheadDist + player.transform.position);
    //Debug.Log(lookAheadDist);
  }


  private void computeMovWayPointSpeed()
  {
    rawVelocity = (player.transform.position - prevPos) / Time.deltaTime;
    velocity = Vector3.SmoothDamp(velocity, rawVelocity, ref smoothingParamVel, smoothingTimeFactor);
    prevPos = player.transform.position;
  }

}
