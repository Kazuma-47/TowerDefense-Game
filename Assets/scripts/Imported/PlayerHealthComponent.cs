using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : HealthComponent
{
    [SerializeField] private PlayerHealthUI playerHealthUI;
        private void Start()
    {
        playerHealthUI.UpdateUI(CurrentHealth);
    }
    protected override void HandleTakeDamage()
    {
        base.HandleTakeDamage();
        playerHealthUI.UpdateUI(CurrentHealth);
    }
    //update je levens 


    protected override void Death()
    {
        base.Death();
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("GameOver");
    }
}
