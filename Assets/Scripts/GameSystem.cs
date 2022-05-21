using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Transform playerTransform;
    public Text scoreText;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        int playerY = Mathf.FloorToInt(playerTransform.position.y);
        score = Mathf.Max(score, playerY);
        scoreText.text = score.ToString();
    }
}
