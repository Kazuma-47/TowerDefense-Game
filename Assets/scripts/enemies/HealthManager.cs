using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthManager : MonoBehaviour
{

    public CreateEnemy createenemy;
    public Slider slider;
    public float Health;
    string Name;
    public TextMeshProUGUI EnemyName;
    public void TakeDamage(float ammount)
    {
        Health -= ammount;
    }

    private void Start()
    {
        Health = createenemy.MaxHP;
        Name = createenemy.Name;
        slider.maxValue = Health;
    }
    private void Update()
    {
        slider.value = Health;
        EnemyName.text = Name;


        if (Health <= 0f)
        {
            FindObjectOfType<Currency>().KilledEnemy(Name);
            Destroy(transform.parent.gameObject);
        }


        /*
            if (Name == "Berserker")
            {
                FindObjectOfType<Currency>().KilledBerserker();
                Destroy(transform.parent.gameObject);
            }
            else if (Name == "Boss")
            {
                FindObjectOfType<Currency>().KilledBoss();
                Destroy(transform.parent.gameObject);
            }
            else if (Name == "Default Enemy")
            {
                FindObjectOfType<Currency>().KilledDefault();
                Destroy(transform.parent.gameObject);
            }

        }
        */
    }
}
