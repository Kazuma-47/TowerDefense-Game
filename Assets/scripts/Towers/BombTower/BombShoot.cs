using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShoot : MonoBehaviour
{
    public shooterAim ShooterAim;
    public GameObject prefab;
    public GameObject spawn;
    public int blspeed = 10;
    public float firerate =1f;
    private Animation Anim;
    [SerializeField] private GameObject gun;

    private void Start()
    {
        Anim = gun.GetComponent<Animation>();
    }



    private void Update()
    {
        firerate -= Time.deltaTime;
        if (firerate< 0f && ShooterAim.target == null)
        {
            firerate = 1f;
        }
        else if (firerate < 0f && !(ShooterAim.target == null))
        {
              Anim.Play("ion_1");

              GameObject bullet = Instantiate(prefab, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), this.gameObject.transform.rotation);
              Rigidbody rb = bullet.GetComponent<Rigidbody>(); 
              bullet.transform.LookAt(ShooterAim.target);
              rb.velocity = transform.forward * blspeed;
              firerate = 1f;


            Destroy(bullet, 3f);
        }

    }
}