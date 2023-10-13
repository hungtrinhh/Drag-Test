using System;
using UnityEngine;

public class testChange : MonoBehaviour
{
    private Player Player;

    private void Start()
    {
        this.Player = GetComponent<Player>();
        this.Player.OnScaleChangeScaleX += Onchange;
    }

    private void OnDestroy()
    {
        this.Player.OnScaleChangeScaleX -= Onchange;

    }

    private void Onchange(float obj)
    {
        Debug.Log(obj);
    }
}