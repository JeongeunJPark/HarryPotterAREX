using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class RaycastFlowerBlossom: MonoBehaviour
{
   
    public GameObject hand;

    private float maxDistance = 30f;

    private GameObject box;

    private Animation boxOpen;

   

    public void Start()
    {
        box = GameObject.FindGameObjectWithTag("BOX");

        boxOpen = box.transform.Find("Chest_01_Top").GetComponent<Animation>();

    }

    // FirstPersonCamera에서 매 프레임 Physics.Raycast를 사용하도록 함.
    // 사용자가 Flower을 응시하면(Raycast 충돌) 꽃이 피어나는 것 처럼 보이도록 함.
    public void Update()
    {

        

        Vector3 rayDirection = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayDirection, out hit, maxDistance))
        {

            Debug.DrawRay(transform.position, rayDirection, Color.green);


            // Raycast가 Flower이외의 물체와 충돌하고 있을 때는
            // Flower를 Seed() 상태로 유지
            if (hit.transform.tag == "BOX")
            { 
                    boxOpen.Play(); 
            }
            // Flower와 충돌하면 충돌한 해당 Flower를 Blossom() 상태로 만듦
            else if (hit.transform.tag == "FLOWER")
            {
                hit.transform.gameObject.SendMessage("Blossom");

            }
            else
            {

            }
        }

       
    }
}
