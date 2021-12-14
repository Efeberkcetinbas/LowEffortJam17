using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private float speed = 3f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Control_Movement();
    }

    void Control_Movement()
    {
        //İki konum arasındaki mesafenin büyüklüğü pozitif
        if (Vector2.Distance(transform.position, player.position) > 0)
        {
            //Objenin konumunu player'ın konumuna hızda yönlendiriyoruz.
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) == 0)
        {
            //aynı konumda demektir
            transform.position = this.transform.position;
        }

        //İki konum arasındaki mesafenin büyüklüğü negatif
        else if (Vector2.Distance(transform.position, player.position) < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
