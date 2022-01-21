using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuned : MonoBehaviour
{
    public EnemyMovement movement;
    public CreateEnemy createenemy;
    private float stunTimer = -1f;
    public int nomalspeed;
    Animator anim;
    public GameObject Model;

    bool isStunned;

    private void Start()
    {
        Model = this.gameObject;
        anim = Model.GetComponent<Animator>();
        movement = GetComponent<EnemyMovement>();
        nomalspeed = createenemy.Speed;
    }
    public void _Stuned(float stunTime)
    {
        stunTimer = stunTime;
        StopCoroutine(StunRoutine());
        StartCoroutine(StunRoutine());

        /*
        isStunned = true;

        movement._speed = 0;
        movement.Walking = false;
        this.anim.SetBool("Walk_Anim", false);
        this.anim.SetBool("Open_Anim", false);
        print(this.anim.GetBool("Walk_Anim"));
        print(this.anim.GetBool("Open_Anim"));
        */

    }
    /*
     void Update()
    {
        StunTimer -= Time.deltaTime;
        if (StunTimer > 0)
        {
            _Stuned();
        }

        else if(StunTimer <= 0)
        {
            movement._speed = nomalspeed;
            movement.Walk();
            

        }

    }
    */

    IEnumerator StunRoutine()
    {
        isStunned = true;

        movement._speed = 0;
        movement.Walking = false;
        movement.Stunned = true;
        this.anim.SetBool("Walk_Anim", false);
        this.anim.SetBool("Open_Anim", false);


        yield return new WaitForSeconds(stunTimer);

        //laat hem weer moven na dat hij klaar is met gestunt zijn

        movement.UnStun();
    }

}
