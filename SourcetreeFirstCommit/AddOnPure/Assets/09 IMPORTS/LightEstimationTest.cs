using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEstimationTest : MonoBehaviour
{

    public float testValue = 0.5f;

     void OnValidate()
    {
        setGlobalLightEstimation(testValue);
    }

    void setGlobalLightEstimation (float lightValue)
    {
        Shader.SetGlobalFloat("_GlobalLightEstimation", lightValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
