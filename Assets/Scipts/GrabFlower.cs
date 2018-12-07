using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFlower : MonoBehaviour
{
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    private GameObject touchedFlower;
    private bool cash = false;
    public Transform anchor;
    private GameObject newflower;
    private Rigidbody rb;
    private int timer1;
    public bool ginsengPickedUp;
    public bool chamomilePickedUp;
    public bool sagePickedUp;
    private bool lockit;
    public OVRGrabber otherscript;

    //private Rigidbody grav;
    // Use this for initialization
    void Start()
    {
        otherscript = GetComponent<OVRGrabber>();
    }

    // Update is called once per frame
    //GameObject instantiatedobject = Instantiate(prefab) as GameObject;
    void Update()
    {
        if (newflower != null)
        {
            newflower.GetComponent<Rigidbody>().velocity = Vector3.zero;
            newflower.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            newflower.GetComponent<Rigidbody>().ResetInertiaTensor();
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (cash == true)
            {
                gettea();


            }
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (cash == false)
            {
                droptea();


            }
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Chamomile"))
        {
            //flower = col.gameObject;
            touchedFlower = flower1;
            cash = true;
            ginsengPickedUp = false;
            sagePickedUp = false;
            Debug.Log("Cham Picked Up");
            chamomilePickedUp = true;
        }
        if (col.CompareTag("Sage"))
        {
            //flower = col.gameObject;
            cash = true;
            touchedFlower = flower2;
            ginsengPickedUp = false;
            sagePickedUp = true;
            Debug.Log("Sage Picked Up");
            chamomilePickedUp = false;
        }
        if (col.CompareTag("Ginseng"))
        {
            //flower = col.gameObject;\
            touchedFlower = flower3;
            cash = true;
            ginsengPickedUp = true;
            sagePickedUp = false;
            chamomilePickedUp = false;
            Debug.Log("Ginseng Picked Up");
        }

    }
    void OnTriggerExit()
    {
        cash = false;
    }
    void gettea()
    {
        otherscript.enabled = false;
        Debug.Log("Flower Grabbed");
        GameObject newflower = Instantiate(touchedFlower, anchor.position, anchor.rotation) as GameObject;
        newflower.transform.SetPositionAndRotation(anchor.position, anchor.rotation);
        newflower.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newflower.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        newflower.GetComponent<Rigidbody>().ResetInertiaTensor();
        newflower.transform.SetParent(anchor);
        cash = false;
        


    }
    void droptea()
    {
        otherscript.enabled = true;
        GameObject newflow = GameObject.FindWithTag("Bulb");
        newflow.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        newflow.transform.parent = null;
        rb = newflow.GetComponent<Rigidbody>();
        rb.useGravity = true;
        Debug.Log("Dropped");
        newflow.tag = "DeadBulb";
    }
}
