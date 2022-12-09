using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemManager : MonoBehaviour
{
    public GameObject totem;
    public GameObject player;
    private Vector3 heading;
    private Vector3 direction;
    private float distance;
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TotemTeleporter");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Totem"))
        {
            heading = totem.transform.position - player.transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
        }
        if (!isPause)
        {
            Teleport();
        }
        
    }

    IEnumerator TotemTeleporter()
    {
        isPause = true;
        yield return new WaitForSeconds(5);
        isPause = false;
    }

    public void Teleport()
    {
        if (distance < 3)
        {
            if (GameObject.FindGameObjectWithTag("Totem"))
            {
                totem.transform.position -= 5 * direction;
            }
            StartCoroutine("TotemTeleporter");
        }
    }
}
