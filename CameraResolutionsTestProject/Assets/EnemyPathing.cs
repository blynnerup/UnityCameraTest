using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPathing : MonoBehaviour
{
    public List<Transform> waypoints;
    public bool isDead = false;
    private Vector3 _startingPosition;

    private int _waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
            Move();
    }

    private void Move()
    {
        var targetPosition = waypoints[_waypointIndex].transform.position;
        var movementThisFrame = 2f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

        if (transform.position == targetPosition)
            _waypointIndex++;

        if (transform.position == targetPosition && _waypointIndex == 2)
            _waypointIndex = 0;

    }
}
