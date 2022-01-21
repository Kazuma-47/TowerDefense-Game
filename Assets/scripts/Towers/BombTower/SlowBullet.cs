using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    public GameObject ob;
    private float _BlastRadius = 2f;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private GameObject Explosion;


    private void Start()
    {
        ob = gameObject;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _BlastRadius, _layer);
            foreach (var Hit in cols)
            {
                Hit.GetComponent<EnemyMovement>().SLowEffect();
            }
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(ob);
        }


        if (collisionInfo.collider.tag == "level")
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _BlastRadius, _layer);
            foreach (var Hit in cols)
            {
                Hit.GetComponent<EnemyMovement>().SLowEffect();
            }
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(ob);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _BlastRadius);
    }
}
