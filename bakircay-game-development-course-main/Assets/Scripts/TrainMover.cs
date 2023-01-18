using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour
{
    [SerializeField] private WayPoints waypoints;
    [SerializeField] public float trainSpeed = 25f;
    private Transform currentWayPoint;
    [SerializeField] private float distanceThreeshol = 0.1f;
    private float yRotation = 180f;
    // Start is called before the first frame update
    void Start()
    {
        currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
        transform.position = currentWayPoint.position;

        currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, trainSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreeshol)
        {
            currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
            yRotation += 90f;
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}
