using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public GameObject antitotem;
    public GameObject player;
    private int stack = 2;
    private int a = 1;
    private bool isPause = false;
    public GameObject totem;
    public GameObject effect;

    private void Start()
    {
        effect.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(antitotem, transform.position + new Vector3(Random.Range(0,3),0, Random.Range(0, 3)), antitotem.transform.rotation);
        GameObject.FindGameObjectWithTag("Antitotem").transform.SetParent(totem.transform);
        effect.SetActive(true);
    }
    

    IEnumerator Damage()
    {
        player.GetComponent<HpManager>().hp -= stack * a;
        isPause = true;
        if (a >= 3)
        {
            GameObject.FindGameObjectWithTag("TotemObject").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Antitotem").GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("TotemObject").GetComponent<MeshRenderer>().enabled = true;
        }
        if (a >= 6)
        {
            effect.SetActive(false);
        }
        yield return new WaitForSeconds(2);
        a++;
        isPause = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isPause)
        {
            StartCoroutine("Damage");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        a = 1;
        Destroy(GameObject.FindGameObjectWithTag("Antitotem"));
        effect.SetActive(false);
    }
}
