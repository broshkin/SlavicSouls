using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject npc;
    public GameObject player;
    public GameObject dialogSystem;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name != "VirtuaLab")
        {
            sprite1.SetActive(false);
            dialogSystem.SetActive(false);
        } 
        if (SceneManager.GetActiveScene().name == "MoonScene")
        {
            Physics.gravity *= 0.166f;
        }
        if (SceneManager.GetActiveScene().name != "MoonScene")
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        var heading = npc.transform.position - player.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        if (SceneManager.GetActiveScene().name != "BridgePractice")
        {
            if(distance < 5)
            {
                if (!dialogSystem.activeSelf)
                {
                   sprite1.SetActive(true);
                   if (Input.GetKeyDown(KeyCode.E))
                   {
                       sprite1.SetActive(false);
                       dialogSystem.SetActive(true);
                       if (SceneManager.GetActiveScene().name == "FirstScene")
                       {
                           dialogSystem.GetComponent<DialogSystem>().StartDialog();
                       }
                   }
                }
                else
                {
                   sprite1.SetActive(false);
                }
 
            }
            else
            {
                if (SceneManager.GetActiveScene().name != "VirtuaLab")
                {
                    sprite1.SetActive(false);
                }
            }
        }

    }
}
