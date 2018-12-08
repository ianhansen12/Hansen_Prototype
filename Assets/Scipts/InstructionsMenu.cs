using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InstructionsMenu : MonoBehaviour
{
    public GameObject Instructions;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            {
                Instructions.SetActive(true);

            }
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
                Instructions.SetActive(false);
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            SceneManager.LoadScene(1);
        }
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            //Quit
            Application.Quit();
        }
    }
}