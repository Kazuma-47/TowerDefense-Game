using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarDIsplay : MonoBehaviour
{
    public GameObject Healthbar;
    public bool Key;
    Camera cam;
    [HideInInspector] public bool mainCAM = true;
    private void Start()
    {
        Healthbar = gameObject.transform.Find("Canvas").gameObject;
        Healthbar.SetActive(false);
        cam = Camera.main;
    }

    public void Display()
    {
        Healthbar.SetActive(true);
    }
    public void Hide()
    {
        Healthbar.SetActive(false);
    }

    public void TerminalCam()
    {
        GetComponent<HealthbarDIsplay>().Display();
        GetComponent<Healthbar>().Main = false;
        //voert voor elke object met die code
        
    }

    void mainCam()
    {
        GetComponent<Healthbar>().Main = true;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Turret")
                {
                    hit.collider.gameObject.GetComponent<HealthbarDIsplay>().Display();
                    Key = true;
                }
                else
                {
                    GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
                    foreach (GameObject turret in turrets)
                    {
                        gameObject.GetComponent<HealthbarDIsplay>().Hide();
                    }
                    Key = false;
                }
            }
            else if (Key == true)
            {
                Key = false;
            }
        }
    }
    void Update()
    {
        if (mainCAM == true)
        {
           mainCam();
        }
        else if( mainCAM == false)
        {
            TerminalCam();
        }
    }
}
