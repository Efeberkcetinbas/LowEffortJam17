using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour,IChanger
{

    private SpriteRenderer sr;

    private bool is_White;

    void Awake()
    {
        is_White = true;
        sr = GetComponent<SpriteRenderer>();
    }

    public bool Change_Color()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return is_White = !is_White;

        return true;
    }

    public void Control_Color()
    {
        if (is_White == true)
            sr.color = Color.white;
        else
            sr.color = Color.black;
    }

    void Update()
    {
        Change_Color();
        Control_Color();
    }
}
