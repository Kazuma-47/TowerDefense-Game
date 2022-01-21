using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public shooterAim ShooterAim;
    public GameObject spawn;
    public float firerate = 1f;
    public float range = 15f;
    public float damage = 1f;
    [SerializeField] private ParticleSystem _Muzleflash;

    [SerializeField] private GameObject Weapon;






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
            if (Physics.Raycast(ShooterAim.partToRotate.transform.position, ShooterAim.partToRotate.transform.forward, out hit, range))
            {
                
                HealthManager Target = hit.transform.GetComponent<HealthManager>();
                if (Target != null)
                {
                   
                    Target.TakeDamage(damage);
                    firerate = 1f;
                    Weapon.GetComponent<Animator>().Play("DefaultTurretShoot");
                    _Muzleflash.Play();
                }
            }
        }

    }
}


