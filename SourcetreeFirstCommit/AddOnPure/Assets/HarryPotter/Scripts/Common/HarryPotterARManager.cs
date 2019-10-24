using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HarryPotterAR
{
    public class HarryPotterARManager : MonoBehaviour
    {
        #region SINGLETON

        private static HarryPotterARManager _instance;
        public static HarryPotterARManager Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        #endregion

        #region Variables



        #endregion

        #region START()

        void Start()
        {
            // 첫 세팅에 싱글톤이 존재하지 않는다면 싱글톤을 생성하고, 그 값은 이 스크립트로 한다.
            if(_instance == null)
            {
                _instance = this;
            }
            // 만약 이미 싱글톤이 존재한다면 '이 스크립트' 를 삭제하여 2개 이상이 존재하지 않도록 한다.
            else
            {
                Destroy(this.gameObject);
                Debug.Log("There is another singleton class instace.");
            }
        }

        #endregion

        #region UPDATE()

        void Update()
        {

        }


        #endregion

        #region CUSTOM Variables


        #endregion

    }
}
