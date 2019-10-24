using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGuideControl : MonoBehaviour
{

    private GameObject mainCamera;


    private Animator handGuideAnim;
    
    //첫 시작동안은 게임 오브젝트가 꺼진 상태를 유지하도록 한다.
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        handGuideAnim = this.gameObject.GetComponent<Animator>();

        //핸드 오브젝트를 setActive(false);
        this.gameObject.SetActive(false);
    }

    //Update 안에서 public static 변수(section 진입 여부)에 따라 모습을 드러낸다.
    void Update()
    {
        //if(CalculateHowFar.in30CmBox || CalculateHowFar.in30CmWeb)
        if (CalculateHowFar.in30CmBox || CalculateHowFar.in30CmWeb)  
        {
            this.gameObject.SetActive(true);
            this.transform.position = mainCamera.transform.position + new Vector3(0f, 0f, 0.8f);
        }

        HandAnimationGuide();
    }

    private void HandAnimationGuide()
    {
        //만약 박스(오픈-클로즈) 와 같은 구역에 있다면
        if (CalculateHowFar.in30CmBox)
        {
            handGuideAnim.SetBool("is30CmBox", true);
        }

        //만약 웹(업-다운) 구역에 있다면
        if (CalculateHowFar.in30CmWeb)
        {
            handGuideAnim.SetBool("is30CmWeb", true);
        }

        //만약 몬스터 사이클에 들어갔다면
        //if(MonsterCycle.IsMonsterExist)
    }
}
