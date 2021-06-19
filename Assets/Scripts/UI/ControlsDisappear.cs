using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDisappear : MonoBehaviour
{
    public Text ReferenceText;  //Add reference to UI Text here via the inspector
    private float timeToAppear = 2.5f;
    private float timeToAppearOnStartup = 5f;
    private float timeWhenDisappear;

    // Start is called before the first frame update
    void Start()
    {
        EnableTextUponStartup();
    }

    //Check every frame if the timer has expired, text should disappear
    void Update()
    {
        if (ReferenceText.enabled && (Time.time >= timeWhenDisappear))
        {
            ReferenceText.enabled = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            EnableText();
        }
    }

    //Call to enable text, which also sets the timer
    public void EnableText()
    {
        ReferenceText.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    //Call to enable text, but stays visible longer than normal
    public void EnableTextUponStartup()
    {
        ReferenceText.enabled = true;
        timeWhenDisappear = Time.time + timeToAppearOnStartup;
    }
}
