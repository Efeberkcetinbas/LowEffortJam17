using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health instance;

    [HideInInspector]
    public int health_number = 1;

    void Start()
    {
        if (instance == null)
            instance = this;
    }
}
