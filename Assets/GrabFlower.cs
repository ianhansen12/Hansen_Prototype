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
    private bool ginsengPickedUp;
    private bool chamomilePickedUp;
    private bool sagePickedUp;
    //private Rigidbody grav;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    //GameObject instantiatedobject = Instantiate(prefab) as GameObject;
    void Update()
    {
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
                Debug.Log("droptea");
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
            chamomilePickedUp = true;
        }
        if (col.CompareTag("Sage"))
        {
            //flower = col.gameObject;
            cash = true;
            touchedFlower = flower2;
            ginsengPickedUp = false;
            sagePickedUp = true;
            chamomilePickedUp = false;
        }
        if (col.CompareTag("Ginseng"))
        {
            //flower = col.gameObject;\
            touchedFlower = flower3;
            cash = true;
            ginsengPickedUp = true;
            sagePickedUp = false;
            chamomilePickedUp = true;
        }
    }
    void OnTriggerExit()
    {
        cash = false;
    }
    void gettea()
    {
        Debug.Log("Flower Grabbed");
        GameObject newflower = Instantiate(touchedFlower, anchor.position, anchor.rotation) as GameObject;
        newflower.transform.SetParent(anchor);
        cash = false;


    }
    void droptea()
    {
        GameObject newflow = GameObject.FindWithTag("Bulb");
        newflow.transform.parent = null;
        rb = newflow.GetComponent<Rigidbody>();
        rb.useGravity = true;
        Debug.Log("Dropped");
        newflow.tag = "DeadBulb";
    }
}
