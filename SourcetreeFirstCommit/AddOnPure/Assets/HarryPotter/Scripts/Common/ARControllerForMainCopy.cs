using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARControllerForMainCopy : MonoBehaviour
{

    private List<TrackedPlane> newTrackedPlanes = new List<TrackedPlane>();

    private GameObject mainCamera;

    public GameObject gridPref;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(GoogleARCore.Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        GoogleARCore.Session.GetTrackables<TrackedPlane>(newTrackedPlanes, TrackableQueryFilter.New); 
        

        for(int i = 0; i < newTrackedPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(gridPref, Vector3.zero, Quaternion.identity, transform);

            grid.GetComponent<GridVisuallizerForMainCopy>().Initialize(newTrackedPlanes[i]);
        }

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            door.SetActive(true);

            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            door.transform.position = hit.Pose.position;
            door.transform.rotation = hit.Pose.rotation;


            //Set position of door And Rotate
            Vector3 cameraPosition = mainCamera.transform.position;

            cameraPosition.y = hit.Pose.position.y +1f;

            door.transform.LookAt(cameraPosition, door.transform.up);
            door.transform.parent = anchor.transform;

        }
    }
}
