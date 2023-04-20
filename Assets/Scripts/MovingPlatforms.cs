using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    // literally just this https://medium.com/nerd-for-tech/moving-platforms-in-unity-86d0c6f05d85
    // thank you James West for sorting out all the confusing bits
    
    //also james west is a clown it didn't work, shoutout chatGPT lol
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private int _currentWaypoint;
    
    private void Start()
    {
        if (waypoints.Count <= 0) return;
        _currentWaypoint = 0;
    }
    private float _waitTime = 1f;
    private bool _isWaiting = false;

    void FixedUpdate()
    {
        if (!_isWaiting)
        {
            // Move the platform towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
                (moveSpeed * Time.deltaTime));
        
            // Check if the platform has reached the current waypoint
            if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0.05f)
            {
                // Set the isWaiting flag to true to start the wait
                _isWaiting = true;
            }
        }
        else
        {
            // Increment the wait timer
            _waitTime -= Time.deltaTime;

            // Check if the wait time has elapsed
            if (_waitTime <= 0f)
            {
                // Reset the wait timer and set the isWaiting flag to false to move to the next waypoint
                _waitTime = 1f;
                _isWaiting = false;

                // Increment the current waypoint index
                _currentWaypoint++;

                // Wrap around to the beginning of the waypoint list if we've reached the end
                if (_currentWaypoint >= waypoints.Count)
                {
                    _currentWaypoint = 0;
                }
            }
        }
    }
}
