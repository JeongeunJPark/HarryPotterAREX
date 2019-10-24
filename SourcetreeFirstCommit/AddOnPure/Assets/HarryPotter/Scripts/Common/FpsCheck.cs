using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCheck : MonoBehaviour
{

    public Text fpsText;

    private float elasped = 0f;

    private int fps = 0;
    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elasped += Time.deltaTime;
        count++;

        if (elasped >= 1f)
        {
            elasped = 0f;

            fps = count;
            count = 0;
        }

        fpsText.text = fps.ToString();
    }
}
