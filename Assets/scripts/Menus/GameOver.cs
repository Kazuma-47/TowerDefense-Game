using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Money", 100);
        SceneManager.LoadScene("Begin screen");
    }
}
