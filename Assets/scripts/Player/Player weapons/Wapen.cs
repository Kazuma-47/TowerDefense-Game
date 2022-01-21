
using UnityEngine;
using UnityEngine.UI;

public class Wapen : MonoBehaviour
{
    public float damage = 1f;
    public float range =100f;

    public ParticleSystem MuzzleFlash;
    public GameObject SelectedBullet;
    public BulletTypes bulletTypes;
    public ParticleSystem MuzzleFlashBullet;
    public float timer;
    public Camera cam;
    public GameObject spawn;




  

    private void Start()
    {
        bulletTypes = GetComponent<BulletTypes>();
        SelectedBullet = bulletTypes.Heal_Bullet;


    }
    void Update() {
        timer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer <= 0) 
        {
            DefaultShot();
        }
        else if (Input.GetButtonDown("1"))
        {
            SwitchBullet1();
        }
        else if (Input.GetButtonDown("2"))
        {
            SwitchBullet2();
        }
        else if (Input.GetButtonDown("3"))
        {
            SwitchBullet3();
        }
        
    }



    void DefaultShot()
    {
        RaycastHit lookingAt;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out lookingAt, range);


       GameObject bullet = Instantiate(SelectedBullet, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), this.gameObject.transform.rotation);
       Rigidbody rb = bullet.GetComponent<Rigidbody>();
       bullet.transform.LookAt(lookingAt.transform);
        rb.velocity = transform.right * 20;
        timer = 1f;
    }
    private void DamageShot()
    {
        
        RaycastHit hit;   //start punt              //waar schiet het   maakt hit var aan voor wat we raakte range is optioneel
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            timer = 1;
            MuzzleFlash.Play();
            MuzzleFlashBullet.Play();
            HealthManager Target= hit.transform.GetComponent<HealthManager>();
            if(Target != null)
            {
                Target.TakeDamage(damage);
            }
        }
    }

    private void SwitchBullet1()
    {
        SelectedBullet = bulletTypes.Heal_Bullet;

    }
    
    private void SwitchBullet2()
    {
        SelectedBullet = bulletTypes.Slow_Bullet;

    }
    
    private void SwitchBullet3()
    {
       
        SelectedBullet = bulletTypes.Damage_Bullet;

    }

}
