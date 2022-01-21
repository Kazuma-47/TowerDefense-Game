using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    Transform camera;
    Camera TerminalCam;
    [HideInInspector] public bool Main= true;
    public GameObject Canvas;
    private void Start()
    {
        camera = Camera.main.transform;
    }
    void Update()
    {

        if(Main == true)
        {
            camera = Camera.main.transform;
            Canvas.transform.LookAt(camera);
        }
      else if(Main == false)
        {
            TerminalCam = GameObject.Find("Camera").GetComponent<Camera>();
            Canvas.transform.LookAt(GameObject.Find("Camera").transform);
        }
    }
}
