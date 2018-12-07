using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupFill : MonoBehaviour {
    private Renderer teaRend;
    private int counter;
    private GameObject waterFull;
    private GameObject waterHalf;
    private Renderer fullrend;
    private Renderer halfrend;
    private bool teaPoured;
    private Material[] materials;
    private Material[] floormaterials;
    public Renderer floorRend;
    float countdown;
    public GameObject skylightobj;
    private Light skyLight;
   // public Color newColor = new Color(0.9339f, 0.9011f, 0.6f, 1f);
   // public Color newColor1 = new Color(0.7641f, 0.3207f, 0.3207f, 1f);
   // public Color newColor2 = new Color(0.8721f, 0.6f, 0.8773f, 1f);

    // Use this for initialization
    void Start ()
    {
        floorRend = GameObject.Find("Floor").GetComponent<Renderer>();
        floormaterials = floorRend.materials;
        floorRend.material = floormaterials[0];
        teaPoured = false;
        waterFull = GameObject.Find("FullWater");
        waterHalf = GameObject.Find("HalfWater");
        fullrend = waterFull.GetComponent<Renderer>();
        halfrend = waterHalf.GetComponent<Renderer>();
        materials = fullrend.materials;
        skyLight = skylightobj.GetComponent<Light>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void teaAppear()
    {
        teaRend = gameObject.GetComponent<Renderer>();
        Debug.Log("Tea Appears");
        teaRend.enabled = true;
        

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Pour"))
        {
            teaAppear();
            waterdisappear();
        }
        if (col.CompareTag("Face"))
        {
            Debug.Log("Drink");
            if (GameObject.FindWithTag("Right").GetComponent<GrabFlower>().chamomilePickedUp == true)
            {
                Debug.Log("cham change environment");
                floorRend.material.color = new Color(0.9339f, 0.9011f, 0.6f, 1f);
                StartCoroutine(StartLightChange());
            }
            if (GameObject.FindWithTag("Right").GetComponent<GrabFlower>().ginsengPickedUp == true)
            {
                Debug.Log("ginseng change environment");
                floorRend.material.color = new Color(0.7830f, 0.5393f, 0.5060f, 1f);
                StartCoroutine(StartLightChange());
            }
            if (GameObject.FindWithTag("Right").GetComponent<GrabFlower>().sagePickedUp == true)
            {
                Debug.Log("sage change environment");
                floorRend.material.color = new Color(0.8721f, 0.6f, 0.8773f, 1f);
                StartCoroutine(StartLightChange());

            }
            teaRend.enabled = false;
            StartCoroutine(StartCountdown());
        }
    }

    void waterdisappear()
    {
        if (teaPoured == false)
        {
            fullrend.enabled = false;
            halfrend.enabled = true;
            teaPoured = true;
        }
        else if (teaPoured == true)
        {
            Debug.Log("empty");
            halfrend.enabled = false;
            teaPoured = false;
            fullrend.material = materials[0];
        }
    }
    public IEnumerator StartCountdown(float countdownValue = 60)
    {
        countdown = countdownValue;
        while (countdown > 0)
        {
            Debug.Log("Countdown: " + countdown);
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
        floorRend.material.color = new Color(0.4450f, 0.6226f, 0.3083f, 1f);
        countdownValue = 60;
    }
    public IEnumerator StartLightChange(float countdownValue = 30)
    {
        countdown = countdownValue;
        while (countdown > 0)
        {
            Debug.Log("Countdown: " + countdown);
            skyLight.intensity = skyLight.intensity * .95f;
            yield return new WaitForSeconds(1.0f);
            countdown--;
            

        }
        StartCoroutine(StartLightChangeBack());
    }
    public IEnumerator StartLightChangeBack(float countdownValue = 30)
    {
        countdown = countdownValue;
        while (countdown > 0)
        {
            if (skyLight.intensity != 0.9f)
            {
                Debug.Log("Countdown: " + countdown);
                skyLight.intensity = skyLight.intensity * 1.05f;
            }
            
            yield return new WaitForSeconds(1.0f);
            countdown--;


        }
    }
}
