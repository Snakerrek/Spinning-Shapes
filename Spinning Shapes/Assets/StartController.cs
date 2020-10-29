using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText = null;
    [SerializeField] TextMeshProUGUI highestScore = null;
    [SerializeField] Button playButton = null;
    [SerializeField] Gradient gradient = null;

    float a = 0f;

    private void Start()
    {
        highestScore.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
    }

    private void Update()
    {
        ChangeColors();
    }

    private void ChangeColors()
    {
        Color color = gradient.Evaluate(a);
        titleText.color = color;
        playButton.GetComponent<Image>().color = color;

        if (a >= 1.0f)
            a = 0f;
        else
            a += 0.001f;
    }
}
