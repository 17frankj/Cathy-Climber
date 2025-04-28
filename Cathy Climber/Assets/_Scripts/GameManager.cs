using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lives = 3; // start at 3 lives
    [SerializeField] String MenuScene;


    public void ExitButton()
    {
        Application.Quit();
    }
}
