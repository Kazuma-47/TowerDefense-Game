using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapError : MonoBehaviour
{
    public float timer;
    public GameObject errorMsg;

    public float Timer
    {
        get { return this.timer; }
        set { this.timer = value; }
    }
    /*
    public void SetTimer(float value)
    {
        this.timer = value;

    }
    public float GetTimer() {
        return this.timer;
    }
    */
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            errorMsg.SetActive(false);
        }
        else
        {
            errorMsg.SetActive(true);
        }
    }
}
