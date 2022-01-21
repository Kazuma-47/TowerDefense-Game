using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public GameObject interact_msg;
    private bool InRange;
    public GameObject Cam;
    public GameObject PlayerCam;
    public GameObject PlayerUI;
    public GameObject ceiling;
    public GameObject TerminalUI;
    public MissionManager QuestManager;

    public bool active = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            interact_msg.SetActive(true);
            InRange = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && InRange == true && active == false)
        {
            //FindObjectOfType<HealthbarDIsplay>().mainCAM = false;
            //doet het voor alle objecten 
            HealthbarDIsplay[] list = FindObjectsOfType(typeof(HealthbarDIsplay)) as HealthbarDIsplay[];
            foreach (HealthbarDIsplay obj in list)
            {
                print(list.Length);

                obj.GetComponent<HealthbarDIsplay>().mainCAM = false;
            }
            TerminalUI.SetActive(true);
            ceiling.SetActive(false);
            Cam.SetActive(true);
            interact_msg.SetActive(false);
            PlayerUI.SetActive(false);
            PlayerCam.SetActive(false);
            active = true;
            QuestManager.Mission_5();
            Cursor.lockState = CursorLockMode.Confined;

        }

        else if (InRange == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            ceiling.SetActive(true);
            interact_msg.SetActive(false);
            Cam.SetActive(false);
            PlayerUI.SetActive(true);
            InRange = false;
            active = false;
            PlayerCam.SetActive(true);
            TerminalUI.SetActive(false);
            //FindObjectOfType<HealthbarDIsplay>().mainCAM = true;

            HealthbarDIsplay[] list = FindObjectsOfType(typeof(HealthbarDIsplay)) as HealthbarDIsplay[];
            foreach (HealthbarDIsplay obj in list)
            {
                print(list.Length);

                obj.GetComponent<HealthbarDIsplay>().mainCAM = true;
            }
        }
        else if (Input.GetKeyDown("e") && active == true && InRange == true)
        {
            TerminalUI.SetActive(false);
            ceiling.SetActive(true);
            interact_msg.SetActive(true);
            Cam.SetActive(false);
            PlayerUI.SetActive(true);
            active = false;
            PlayerCam.SetActive(true);
            //FindObjectOfType<HealthbarDIsplay>().mainCAM = true;

            HealthbarDIsplay[] list = FindObjectsOfType(typeof(HealthbarDIsplay)) as HealthbarDIsplay[];
            foreach (HealthbarDIsplay obj in list)
            {
                print(list.Length);

                obj.GetComponent<HealthbarDIsplay>().mainCAM = false;
            }

        }

    }

    public void OnTriggerExit(Collider other)
    {
        PlayerCam.SetActive(true);
        interact_msg.SetActive(false);
        InRange = false;
        active = false;

    }
}
