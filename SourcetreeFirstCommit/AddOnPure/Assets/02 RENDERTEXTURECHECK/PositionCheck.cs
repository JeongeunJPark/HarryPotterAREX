using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionCheck : MonoBehaviour
{
    public GameObject FirstPersonCam;

   // public GameObject FrameClone;

    public Text firstText;
    //public Text cloneText;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FirstPersonCamPosition = FirstPersonCam.transform.position;

       // Vector3 FrameClonePosition = FrameClone.transform.position;


        firstText.text = FirstPersonCamPosition.ToString();
       // cloneText.text = FrameClonePosition.ToString();

    }
}
