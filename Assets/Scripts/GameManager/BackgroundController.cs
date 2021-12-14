using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour, IChanger
{
    bool is_White;

    private SpriteRenderer sr;

    public bool Change_Color()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return is_White = !is_White;
        }

        return true;
    }

    public void Control_Color()
    {
        if (is_White == false)
            sr.color = Color.black;
        else
            sr.color = Color.white;
    }

    void Awake()
    {
        is_White = false;

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Change_Color();
        Control_Color();
    }
}
