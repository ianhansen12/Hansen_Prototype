using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfill : MonoBehaviour {
    public Renderer rend;
    public bool isBoiled;
    public int timer;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update() {
    }
    public void waterappear()
    {
        rend = gameObject.GetComponent<Renderer>();
        Debug.Log("Water Appears");
        rend.enabled = true;
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Water"))
        {
            waterappear();
        }

        if (col.CompareTag("Fire"))
        {
            //timer 
            Debug.Log("Boiling has begun");
            InvokeRepeating("boiler", 1f, 1f);
         }
    } 
    void boiler()
    {
        timer++;
        if (timer == 3)
    {
        Debug.Log("Yeet");
    }
    }
}
