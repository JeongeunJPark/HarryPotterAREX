using UnityEngine;

using System.Collections;

 

public class PlantRotate : MonoBehaviour 

{
    //GameObject �� Cam �̶� ���������ϱ�?
    //�ҽ��ڵ� �ڵ����� Cam �����ǵ��� ������ ��
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