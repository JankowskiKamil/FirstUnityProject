using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] wayPoints;

    private int currentWayPointIntex = 0;

    private float distanceTolerance = .1f;

    [SerializeField] private float movementSpeed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentWayPointIntex].transform.position) < distanceTolerance)
        {
            currentWayPointIntex++;
            if (currentWayPointIntex >= wayPoints.Length) currentWayPointIntex = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPointIntex].transform.position, movementSpeed * Time.deltaTime );
    }


}
