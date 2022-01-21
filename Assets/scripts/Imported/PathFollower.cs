using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arealThreshold;
    
    private Path _path;
    private Waypoint _currentWaypoint;


    private void Start()
    {
        SetupPath();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward *_speed* Time.deltaTime);
        float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.GetPosition());
        if(distanceToWaypoint <= _arealThreshold)
        {
            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            else
            {
                _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
                transform.LookAt(_currentWaypoint.GetPosition());
            }
        }
    }
    private void SetupPath()
    {
       
        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
        transform.LookAt(_currentWaypoint.GetPosition());
    }

    private void PathComplete()
    {
        _speed = 0;
        print("arived");
        //FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
        Destroy(gameObject);
    }
}
