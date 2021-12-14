using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    public float score;

    public static SetScore instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        score += Time.deltaTime;
    }
}
