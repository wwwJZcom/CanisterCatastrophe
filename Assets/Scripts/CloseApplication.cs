using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApplication : MonoBehaviour
{
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game has closed!");
    }
}
