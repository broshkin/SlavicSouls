using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpManager : MonoBehaviour
{
    public int hp = 100;
    public TextMeshProUGUI hp_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        hp_text.text = hp.ToString() + " HP";
        if (hp <= 0)
        {
            gameObject.transform.position = new Vector3(8.72f, 3.2f, -26.02f);
            hp = 100;
        }
    }
}
