using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavour : MonoBehaviour
{

    public void StartGame()
    {
        
        PlayerPrefs.SetFloat("Money", 100);
        SceneManager.LoadScene("GameScreen");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
