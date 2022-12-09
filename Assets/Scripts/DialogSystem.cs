using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] lines;
    [SerializeField] float TextSpeed;

    private int index;

    public GameObject player;
    public GameObject canvas;
    public int thisNumDialogIsFinished = 0;
    void Start()
    {
        text.text = lines[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == lines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    public void StartDialog()
    {
        index = 0;
        TypeLine();
    }

    public void TypeLine()
    {
        if (lines[index] != string.Empty)
        {
            text.text = lines[index];
        }
        else
        {
            IsNextLine();
        }
    }


    void IsNextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            TypeLine();
        }
        else
        {
            gameObject.SetActive(false);
            index = 0;
            text.text = lines[index];
        }
    }
}