using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int scores;
    public static GameManager inst;
    public Text ScoreText;

    private void Awake()
    {
        inst = this;
    }

    public void IncrementScore()
    {
        scores++;
        ScoreText.text = "Score: " + scores; 
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
