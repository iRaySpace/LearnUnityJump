using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTransform;
    public Text scoreText;

    public static int score;

    private float maxPlayerY;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        maxPlayerY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int playerY = Mathf.FloorToInt(playerTransform.position.y);
        score = Mathf.Max(score, playerY);
        scoreText.text = score.ToString();

        maxPlayerY = Mathf.Max(maxPlayerY, playerTransform.position.y);
        cameraTransform.position = new Vector3(cameraTransform.position.x, maxPlayerY, cameraTransform.position.z);
    }
}
