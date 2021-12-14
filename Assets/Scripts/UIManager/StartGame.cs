using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartGame : MonoBehaviour
{
    [SerializeField] private float x, y, duration, jumpPower;


    void Start()
    {
        transform.DOJump(new Vector2(x, y), jumpPower,1,duration).SetLoops(-1,LoopType.Yoyo);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Me"))
        {
            transform.DOPunchScale(new Vector2(0.5f, 0.5f), 2);
            StartCoroutine(Kill_Tween(2.1f));
            StartCoroutine(GameScene(2.5f));
        }
        
    }


    IEnumerator GameScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Kill_Tween(float time)
    {
        yield return new WaitForSeconds(time);
        DOTween.KillAll();
    }


}
