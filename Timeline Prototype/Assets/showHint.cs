using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHint : MonoBehaviour {


    
    public Camera mainCamera;

    public GameObject prefab;
    public GameObject prefabIntersection;
    public GameObject prefabNoImage;
    public GameObject prefabIntersectionNoImage;


    public Text hintText;
    // public LineRenderer raycastLineRenderer;
    // Use this for initialization
    void Start () {
        //raycastLineRenderer.SetWidth(0.1f, 5f);
        hintText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //print("running");
        RaycastHit hit;
        Ray forwardRay;
        //Vector3 testPosition = new Vector3(0, 90, 0);
        Vector3 cameraDirection = new Vector3(mainCamera.transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, mainCamera.transform.eulerAngles.z);
        //forwardRay = new Ray(mainCamera.transform.position, mainCamera.transform.rotation);

        //Vector3 fwd = mainCamera.transform.TransformDirection(Vector3.forward);
        //Debug.DrawLine(mainCamera.transform.position, fwd*50, Color.green);
        //Vector3 raycastEndPoint = new Vector3(mainCamera.transform.position.x+500, mainCamera.transform.position.y, mainCamera.transform.position.z);
        //Debug.DrawRay(mainCamera.transform.position, raycastEndPoint, Color.green);

        //Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.rotation, Color.red);
        //        if (Physics.Raycast(forwardRay, out hit, 10000)) {

        //            //print(hit.transform.gameObject);
        //            //print(cameraDirection);
        //            print(mainCamera.transform.rotation);
        //            print("IT HIT@@@@@@@@@@@@@@");
        //            //if (hit.transform.gameObject == gonzagaPath)
        //            //{
        //            //    gonzagaPathTitle.gameObject.SetActive(true);
        //            //    philanthropyPathTitle.gameObject.SetActive(false);
        //            //    comingOfAgePathTitle.gameObject.SetActive(false);
        ////
        //            } else {
        //            //print(cameraDirection);
        //            print(mainCamera.transfrom.roation);
        //            print("IDK WATS HAPPENING?!?!?");
        //            }
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 500))
        {
            //print("hit detected");
           // print(hit.transform.gameObject);
           // print(prefab);
            //if (hit.transform.gameObject == prefab || hit.transform.gameObject == prefabIntersection || hit.transform.gameObject == prefabIntersectionNoImage || hit.transform.gameObject == prefabNoImage) {
            //    print("billboard hit");
            //}
            if (hit.transform.gameObject.tag == "billboard") {
                hintText.text = "Double Click On An Event To Learn More";
               // print("HIT THE BILLBOARD");
            }
        }
        else {
            hintText.text = "";
            //print("notta");
        }
    }
}
