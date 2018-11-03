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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    //GameObject instantiatedobject = Instantiate(prefab) as GameObject;
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if(cash == true)
            {
                gettea();
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
            }
            if (col.CompareTag("Sage"))
            {
                //flower = col.gameObject;
                cash = true;
                touchedFlower = flower2;
            }
            if (col.CompareTag("Ginseng"))
            {
            //flower = col.gameObject;\
                touchedFlower = flower3;
                cash = true;                
            }
    }
    void OnTriggerExit()
    {
        cash = false;
    }
    void gettea()
    {
        Debug.Log("Flower Grabbed");
        GameObject newflower = Instantiate(touchedFlower) as GameObject;
        newflower.transform.SetParent(anchor);
    }
}
