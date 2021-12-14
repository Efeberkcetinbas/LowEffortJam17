using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score_Text;

    [SerializeField] private bool is_Delete = false;

    [HideInInspector]
    public float score_float;

    public int score_int;

    void Awake()
    {
        if (is_Delete == true)
            PlayerPrefs.DeleteAll();

        score_float = PlayerPrefs.GetFloat("score");
    }

    void Start()
    {
        score_int = (int)score_float;
        _score_Text.text = score_int.ToString();
    }

    void Update()
    {
        score_int = (int)score_float;
        _score_Text.text = score_int.ToString();
    }
}
