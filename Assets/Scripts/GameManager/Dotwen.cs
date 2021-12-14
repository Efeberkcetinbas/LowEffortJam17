using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Dotwen : MonoBehaviour
{
    private float x=1, 
        y=1, 
        duration=2;

    public bool is_collided = false;

    void Start()
    {
        is_collided = false;
        transform.DOScale(new Vector2(x, y), duration);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.DOScale(new Vector2(0.1f, 0.1f), duration);
            StartCoroutine(Destroy(2));
            DOTween.Kill(gameObject);
        }

        else if (collision.gameObject.CompareTag("Me"))
        {
            PlayerPrefs.SetFloat("score", SetScore.instance.score);
            //Mesela canımız olur. Burada canımızı azaltırız. 3 candan biri gitti.
            Health.instance.health_number -= 1;
            transform.DOPunchScale(new Vector2(0.5f, 0.5f), 1);
            is_collided = true;
            StartCoroutine(Destroy_Tween(1.5f));
            StartCoroutine(Game_Over(1.6f));
        }
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator Destroy_Tween(float time)
    {
        yield return new WaitForSeconds(time);
        DOTween.KillAll();
    }

    IEnumerator Game_Over(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
