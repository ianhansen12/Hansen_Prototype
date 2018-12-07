using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour {
    public GameObject Instructions;
    public GameObject StartMenu;
    // Use this for initialization
    void Start () {
	}
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene(1);
        }
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            //Quit
           Application.Quit();
        }
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
                Debug.Log("InstructionLoad");
                StartMenu.SetActive(false);
                Instructions.SetActive(true);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("InstructionLoad");
            StartMenu.SetActive(true);
            Instructions.SetActive(false);
        }
    }
}
