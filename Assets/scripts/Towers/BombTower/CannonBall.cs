using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject ob;
    private float _BlastRadius= 2f;
    [SerializeField] private LayerMask _layer;
    public float BlastDamage =2f;
    [SerializeField] private GameObject Explosion;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _BlastRadius, _layer);
            foreach (var Hit in cols)
            {
                Hit.GetComponent<HealthManager>().Health-= BlastDamage;
            }


            collisionInfo.gameObject.GetComponent<HealthManager>().Health -= 2f;

            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(ob);
        }


        if (collisionInfo.collider.tag == "level")
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _BlastRadius, _layer);
            foreach (var Hit in cols)
            {
                Hit.GetComponent<HealthManager>().Health -= BlastDamage;
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
