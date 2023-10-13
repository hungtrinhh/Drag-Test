using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogNamePlayer : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(Player.Instance.name);
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Player.Instance.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.Instance.name);
    }
}