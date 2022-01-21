using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
public void KilledDefault()
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money")+ 10);
    }
    public void KilledBerserker()
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 15);
    }
    public void KilledBoss()
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 20);
    }


    public void KilledEnemy(string Name)
    {
        if (Name == "Berserker")
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 15);
        }
        else if (Name == "Boss")
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 20);
        }
        else if (Name == "Default Enemy")
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 10);
        }
    }
}
