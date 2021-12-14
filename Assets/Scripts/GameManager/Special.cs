using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour, IChanger
{
    private Rigidbody2D rb2d;

    private SpriteRenderer sr;

    [SerializeField]
    private int number;

    bool is_White;

    [SerializeField] private float _become_Small_Speed = 3f;

    void Awake()
    {
        number = Random.Range(0, 360);
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Change_Color();
        Control_Color();
    }

    public bool Change_Color()
    {
        if (number % 2 == 0)
            return is_White = true;
        else
            return is_White = false;
    }

    public void Control_Color()
    {
        if (is_White == true)
            sr.color = Color.white;
        else
            sr.color = Color.black;
    }
}
