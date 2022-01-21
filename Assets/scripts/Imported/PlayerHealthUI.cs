using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private PlayerHealthComponent _playerHealthComponent;
    public float _currentHealth;
   

 
    
    public void UpdateUI(float lifes)
    {
       _text.text = lifes.ToString();
    }
}
