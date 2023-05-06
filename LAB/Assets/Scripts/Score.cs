using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] public const float DEFAULT_POINTS = 1;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AddPoints(float points)
    {
        score += points;
        scoreUI.text = "SCORE: " + score;
    }

}
