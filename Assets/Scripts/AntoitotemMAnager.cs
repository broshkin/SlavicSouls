using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntoitotemMAnager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.FindGameObjectWithTag("Totem"));
        GameObject.FindGameObjectWithTag("Effect").SetActive(false);
    }
}
