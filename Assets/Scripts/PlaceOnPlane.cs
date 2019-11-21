using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PlaceOnPlane : MonoBehaviour
{
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits;

    public GameObject model;
    //public GameObject cube;

    bool firstTouch = false;


    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    }


    void Update()
    {
        if (!firstTouch)
        {        
            if (Input.touchCount == 0)
                return;

            Touch touch = Input.GetTouch(0);

            if (raycastManager.Raycast(touch.position, hits))
            {
                Pose pose = hits[0].pose;

                Instantiate(model, pose.position, pose.rotation);            

                firstTouch = true;
            }
        }
    }
}