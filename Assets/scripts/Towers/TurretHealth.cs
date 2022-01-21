using UnityEngine;
using UnityEngine.UI;


public class TurretHealth : MonoBehaviour
{

    public TurretStats turretStats;
    public Slider slider;
    public float Health;

    public void TakeDamage(float ammount)
    {
        Health -= ammount;
    }

    private void Start()
    {
        Health = turretStats.Health;
        slider.maxValue = Health;
    }
    private void Update()
    {

        slider.value = Health;
        if(Health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
