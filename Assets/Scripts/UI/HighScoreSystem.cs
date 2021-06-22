using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreSystem : MonoBehaviour
{
    public static int highScoreValue = 0;
    Text score;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + highScoreValue;

        if (highScoreValue <= 0)
        {
            highScoreValue = 0;
        }
    }
}
