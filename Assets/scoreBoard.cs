using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreBoard : MonoBehaviour
{
    [SerializeField] int score;
    Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }
    public void ScorePerHit(int scoreincrease)
    {
        score = score + scoreincrease;
        scoretext.text = score.ToString();
        // takes score then adds scoreperhit
        // displays as new scoretext as a string
    }
}
