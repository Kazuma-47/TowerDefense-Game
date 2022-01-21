using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{ 
    public shooterAim SA;
    public float firerate = 0.7f;

    void Update()
    {
        firerate -= Time.deltaTime;
        if (firerate < 0f && SA.target == null)
        {
            firerate = 1f;
            print(SA.target);
        }
        else if (firerate < 0f && !(SA.target == null))
        {
            Debug.Log("Burn");
            //damge doen aan enemy zodra dit af gaat
            //enemyhp- 10;
            firerate = 0.7f;
        }

    }
}
