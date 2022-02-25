using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        Application.LoadLevel(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
