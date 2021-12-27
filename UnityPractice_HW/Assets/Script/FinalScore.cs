using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public int finalscore;
    public static FinalScore inst;
    public Text ScoreText;
    private void Awake()
    {
        inst = this;
    }

    public void ShowScore()
    {
        ScoreText.text = "Score: " + finalscore;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
