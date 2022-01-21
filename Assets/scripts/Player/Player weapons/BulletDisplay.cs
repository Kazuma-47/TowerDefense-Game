using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletDisplay : MonoBehaviour
{
    public Sprite Heal;
    public Sprite Damage;
    public Sprite Slow;
    public Image selectedBullet_sprite;
    void Start()
    {
        selectedBullet_sprite.sprite = Heal;
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (Input.GetButtonDown("1"))
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


    private void SwitchBullet1()
    {
        selectedBullet_sprite.sprite = Heal;
    }

    private void SwitchBullet2()
    {
        selectedBullet_sprite.sprite = Slow;
    }

    private void SwitchBullet3()
    {
        selectedBullet_sprite.sprite = Damage;
    }

}
