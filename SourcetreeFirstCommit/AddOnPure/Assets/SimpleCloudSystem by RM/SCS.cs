using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HarryPotterAR
{
    public class SCS : MonoBehaviour
    {
        private Transform player;
        private float cloudsSpeed = 2f;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        }


        // Update is called once per frame
        void Update()
        {
            if (!player)
            {
                return;
            }
            else
            {
                gameObject.transform.position = player.transform.position;

                transform.Rotate(0, Time.deltaTime * cloudsSpeed, 0);
            }
           
        }
    }
}