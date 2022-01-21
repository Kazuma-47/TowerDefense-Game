using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CreateEnemy createenemy;
    [SerializeField] private Waypoint _currentWaypoint;
    public int _speed ;
    Animator anim;
    private Path _path;
    public GameObject Modiel;
    public Transform parent;
    [HideInInspector] public bool Walking = false;
    [HideInInspector] public bool Stunned = false;
    [SerializeField] private float _arealThreshold;

    public int slowSpeed;
    public float slowTimer =0;


    private void Start()
    {
        SetupPath();
        anim = GetComponent<Animator>();
        _speed = createenemy.Speed;
        slowSpeed = _speed - 2;
    }


    // Update is called once per frame
    void Update()
    {
        slowTimer -= Time.deltaTime;

        if (Walking == true && slowTimer <= 0)
        {
            anim.SetBool("Walk_Anim", true);
            anim.SetBool("Open_Anim", true);
            parent.transform.LookAt(_currentWaypoint.GetPosition());
            parent.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            float distanceToWaypoint = Vector3.Distance(parent.transform.position, _currentWaypoint.GetPosition());
            if (distanceToWaypoint <= _arealThreshold)
            {
                if (_currentWaypoint == _path.GetPathEnd())
                {
                    PathComplete();
                }
                else
                {
                    _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
                    parent.transform.LookAt(_currentWaypoint.GetPosition());
                }
            }
        }
        else if (Walking = true && slowTimer >= 0 && Stunned == false)
        {
            Debug.Log(Walking);
            anim.SetBool("Walk_Anim", true);
            anim.SetBool("Open_Anim", true);
            parent.transform.LookAt(_currentWaypoint.GetPosition());
            parent.transform.Translate(Vector3.forward * slowSpeed * Time.deltaTime);
        }
    }

    private void PathComplete()
    {
        _speed = 0;
        print("arived");
        FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
        Destroy(gameObject);
    }
    private void SetupPath()
    {

        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
        parent.transform.LookAt(_currentWaypoint.GetPosition());
    }

    public void Walk()
        {
            Walking = true;
            Stunned = false;
      
        }
    public void UnStun()
    {
        anim.SetBool("Walk_Anim", true);
        anim.SetBool("Open_Anim", true);
        _speed = createenemy.Speed;
    }

    public void SLowEffect()
    {
        slowTimer = 3f;
    }
 

}
