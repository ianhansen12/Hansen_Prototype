using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfill : MonoBehaviour {
    public Renderer rend;
    private Material[] materials;
    private bool isBoiled;
    private int timer;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update() {
    }
    public void waterappear()
    {
        rend = gameObject.GetComponent<Renderer>();
        materials = rend.materials;
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
            Debug.Log("Boiling has begun");
            InvokeRepeating("boiler", 1f, 1f);
         }
        if (col.CompareTag("Bulb"))
        {
            Debug.Log("Tea");
        }
    } 
    void boiler()
    {
        timer++;
        if (timer == 3)
        {
            Debug.Log("Yeet");
            isBoiled = true;
            rend.material = materials[1];

        }
    }
}
