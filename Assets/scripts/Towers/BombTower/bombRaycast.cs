using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombRaycast : MonoBehaviour
{
    public shooterAim ShooterAim;
    public GameObject spawn;
    public float firerate = 1f;
    public float range = 15f;
    public float damage = 3f;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Weapon;

    public float BlastDamage = 2f;
    private float _BlastRadius = 2f;
    [SerializeField] private LayerMask _layer;

    private Animation Anim;

    private void Start()
    {
        Anim = Weapon.GetComponent<Animation>();
    }


    private void Update()
    {

        firerate -= Time.deltaTime;
        if (firerate <= 0f && ShooterAim.target == null)
        {
            firerate = 1f;

        }
        else if (firerate <= 0f && !(ShooterAim.target == null))
        {
            RaycastHit hit;   //start punt              //waar schiet het   maakt hit var aan voor wat we raakte range is optioneel
            if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, range))
            {
                HealthManager Target = hit.transform.GetComponent<HealthManager>();
                if (Target != null)
                {
                    Target.TakeDamage(damage);
                    firerate = 1f;
                    Anim.Play("ion_1");
                    Instantiate(Explosion, Target.transform.position, Quaternion.identity);

                    Collider[] cols = Physics.OverlapSphere(transform.position, _BlastRadius, _layer);
                    foreach (var Hit in cols)
                    {
                        Hit.GetComponent<HealthManager>().Health -= BlastDamage;
                    }
                }
            }
        }

    }
}


