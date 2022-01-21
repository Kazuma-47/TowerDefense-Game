using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public TextMeshProUGUI Description;
    private string CurrentMission;
    public GameObject Generator;
    public GameObject UpgradeBench;
    public GameObject Data;
    public GameObject Terminal;

    private void Start()
    {
        Mission_1();
    }
    private void Update()
    {
        Description.text = CurrentMission;
    }
    private void Mission_1()
    {
        CurrentMission = "Turn on Electricity";
        Generator.SetActive(true);
    }

    public void Mission_2()
    {
        Generator.SetActive(false);
        UpgradeBench.SetActive(true);
        Data.SetActive(false);
        CurrentMission = "Move to The upgrade station and buy a turret and tool";
    }
    public void Mission_3()
    { 
        UpgradeBench.SetActive(false);
        Data.SetActive(true);
        Generator.SetActive(false);
        CurrentMission = "Check the Data Unit for Information about enemy units";
    }

    public void Mission_4()
    {
        Generator.SetActive(false);
        UpgradeBench.SetActive(false);
        Data.SetActive(false);
        Terminal.SetActive(true);
        CurrentMission = "Go to the terminal place a turret and start the wave";
    }

    public void Mission_5()
    {
        Generator.SetActive(false);
        UpgradeBench.SetActive(false);
        Data.SetActive(false);
        Terminal.SetActive(false);
        CurrentMission = "Survive";
    }

}


