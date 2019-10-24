using UnityEngine;

using System.Collections;

 

public class PlantRotate : MonoBehaviour 

{
    //GameObject 랑 Cam 이랑 무슨차이일까?
    //소스코드 자동으로 Cam 배정되도록 수정할 것
    private GameObject cameraToLookAt;

    private void Start()
    {
        cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera") ;
    }

    void Update () 

    {

        Vector3  v = cameraToLookAt.transform.position  - transform.position ;

        v.x = v.z = 0.0f;

        transform.LookAt (cameraToLookAt.transform.position  - v); 

    }

}