using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Type", menuName = "enemy health")]
public class CreateEnemy : ScriptableObject
{
    public string Name;
    public int MaxHP;
    public int Speed;
    
}
