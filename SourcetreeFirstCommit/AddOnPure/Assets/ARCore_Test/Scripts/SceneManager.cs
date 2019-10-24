using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

namespace ARCore_Test
{
    public class SceneManager : MonoBehaviour
    {
        //screen center 지점에 면이 없을 경우 임의의 nonTargetObj를 위치할 z position 값
        protected const float DEFAULT_NON_TARGET_Z_POS = 1.5f;

        [SerializeField]
        protected Camera arCamera;

        //screen center 지점에 면이 있을 경우 object로 사용할 prefab
        [SerializeField]
        protected GameObject targetPrefab;
        //screen center 지점에 면이 없을 경우 object 로 사용할 prefab
        [SerializeField]
        protected GameObject nonTargetPrefab;
        //사용자가 선택한 면의 위치에 놓일 object로 사용할 prefab
        [SerializeField]
        protected GameObject surfacePrefab;

        //screen center 지점에 면이 있을 경우 object
        protected GameObject targetObj;
        //screen center 지점에 면이 없을 경우 object
        protected GameObject nonTargetObj;

        //사용자가 선택한 면의 위치에 놓일 object
        protected GameObject surfaceObj;

        protected bool m_IsQuitting = false;

        //사용자가 선택한 면의 위치에 object가 놓여 있는지 확인하는 flag
        protected bool attachSurfaceObj = false;

        //screen center 지점
        protected Vector2 screenCenterVector2;

        // Start is called before the first frame update
        void Start()
        {
            //screen center 지점 설정
            screenCenterVector2 = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        }

        public void Update()
        {
            _UpdateApplicationLifecycle();

            //Touch touch;
            
            // Raycast against the location the player touched to search for planes.
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;
            
            //사용자가 면에 놓은 오브젝트가 없을 시
            if (!attachSurfaceObj) 
            {
                //screen center 좌표 기준으로 면을 찾음
                bool raycastring = Frame.Raycast(screenCenterVector2.x, screenCenterVector2.y, raycastFilter, out hit);
                //면이 있을 시
                if (raycastring)
                {
                    //면이 있을 경우의 object가 초기 상태라면
                    if (targetObj == null)
                    {
                        //prefab을 GameObject로 복사
                        targetObj = Instantiate(targetPrefab);
                        //면을 찾은 Pose정보를 이용하여 Anchor 생성
                        var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                        //생성된 Anchor 를 GameObejct의 parent trasnform으로 설정
                        targetObj.transform.parent = anchor.transform;
                    }
                    //면을 찾은 Pose 정보를 이용하여,, 면이 있는 경우의 object의 position, rotation 설정
                    targetObj.transform.SetPositionAndRotation(hit.Pose.position, hit.Pose.rotation);
                }
                //면이 없을 시
                else
                {
                    //면이 없는 경우의 object가 초기 상태라면 prefab을 GameObject로 복사
                    if (nonTargetObj == null) nonTargetObj = Instantiate(nonTargetPrefab);
                    //screen center 값을 camera를 이용하여 world Position을 좌표계 수정, 그때의 z값은 임의의 DEFAULT_NON_TARGET_Z_POS 로 위치
                    nonTargetObj.transform.position = arCamera.ScreenToWorldPoint(new Vector3(screenCenterVector2.x, Screen.height - screenCenterVector2.y,
                            DEFAULT_NON_TARGET_Z_POS));
                    //rotation 설정
                    nonTargetObj.transform.rotation = Quaternion.identity;
                }
                //면을 찾은 결과에 따른, targetObj와 nonTargetObj의 active 설정
                if (targetObj != null) targetObj.SetActive(raycastring);
                if (nonTargetObj != null) nonTargetObj.SetActive(!raycastring);

                //touch count가 0 이상이며 면이 있는 경우의 object가 렌더링되고 있을 시
                if (Input.touchCount > 0 && targetObj.activeSelf)
                {
                    //터치와 면을 찾는 flag를 설정
                    attachSurfaceObj = true;
                    //면을 찾은 결과에 따른, targetObj와 nonTargetObj을 inactive로 설정
                    targetObj.SetActive(false);
                    nonTargetObj.SetActive(false);

                    //사용자가  선택한 면의 위치에 놓일 object가 초기 상태라면 prefab을 이용하여 GameObject로 생성
                    if (surfaceObj == null) surfaceObj = Instantiate(surfacePrefab);
                    //면이 있는 경우의 Object의 trasnform 정보를 설정
                    surfaceObj.transform.SetPositionAndRotation(targetObj.transform.position, targetObj.transform.rotation);
                }
            }
        }

        /// <summary>
        /// Check and update the application lifecycle.
        /// </summary>
        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (GoogleARCore.Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }

            // Quit if ARCore was unable to connect and give Unity some time for the toast to
            // appear.
            if (GoogleARCore.Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (GoogleARCore.Session.Status.IsError())
            {
                _ShowAndroidToastMessage(
                    "ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        /// <summary>
        /// Actually quit the application.
        /// </summary>
        private void _DoQuit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Show an Android toast message.
        /// </summary>
        /// <param name="message">Message string to show in the toast.</param>
        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject =
                        toastClass.CallStatic<AndroidJavaObject>(
                            "makeText", unityActivity, message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}