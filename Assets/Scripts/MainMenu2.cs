using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu2 : MonoBehaviour
{
    public GameObject menuMain;
    public GameObject menuControl;

    void Start()
    {
        menuMain.SetActive(true);
        menuControl.SetActive(false);
    }
}
