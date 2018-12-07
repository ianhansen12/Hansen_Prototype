using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfill : MonoBehaviour {
    public Renderer rend;
    private Material[] materials;
    private bool isBoiled;
    private bool teaPresent;
    private bool fireready;
    private float countdown;
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
        rend.material = materials[0];
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
            fireready = true;
            // InvokeRepeating("boiler", 1f, 1f);
            StartCoroutine(StartBoil());
        }
        if (col.CompareTag("DeadBulb"))
        {
            Debug.Log("Tea");
            teaPresent = true;
        }
    } 
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Fire"))
        {
            fireready = false;
            Debug.Log("No More boily boily");
        }
    }
    //void boiler()
   // {
   //     Debug.Log("Boiling has begun");
   //
   //     if (timer == 10 && teaPresent == true && fireready == true)
   //     {
   //         Debug.Log("Yeet");
   //         rend.material = materials[1];
    //        teaPresent = false;
   //         timer = 0;
   //     }
   //     timer++;
   // }
    public IEnumerator StartBoil(float countdownValue = 10)
    {
        countdown = countdownValue;
        while (countdown > 0)
        {
            Debug.Log("Countdown: " + countdown);
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
        if (fireready == true && teaPresent == true)
        {
            Debug.Log("Yeet");
            rend.material = materials[1];
            teaPresent = false;
        }

    }
}
