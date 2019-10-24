using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateHowFar : MonoBehaviour
{

    //거리 계산 Boolean 상자-카메라 
    public static bool in30CmBox = false;

    //거리 계산 Boolean 책꽂이-카메라
    public static bool in30CmWeb = false;


    private GameObject chest;

    private GameObject bookcase;

    private GameObject mainCamera;

    private Text finish;
    
    
    // Start is called before the first frame update
    void Start()
    {
        chest = GameObject.FindGameObjectWithTag("BOX");

        bookcase = GameObject.FindGameObjectWithTag("BOOKCASE");

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        getDistance();


        
    }

    public void getDistance()
    {

        //Box position을 계산
        Vector3 chestPosition = chest.transform.position;

        //Bookcase position을 계산
        Vector3 bookcasePosition = bookcase.transform.position;

        //mainCamera position을 계산
        Vector3 mainCameraPosition = mainCamera.transform.position;

        //거리 계산 유저-박스
        float distanceBox = Vector3.Distance(mainCameraPosition, chestPosition);

        //거리 계산 유저-책꽂이
        float distanceBookcase = Vector3.Distance(mainCameraPosition, bookcasePosition);

        finish.text = distanceBox.ToString();

        //일정 거리 이상 가까워지면 in30cm = true;
        if (distanceBox <= 0.5f)
        {
            in30CmBox = true;
        }

        if(distanceBookcase <= 0.5f)
        {
            in30CmWeb = true;
        }
    }
}
