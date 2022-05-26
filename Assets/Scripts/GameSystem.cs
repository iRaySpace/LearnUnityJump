using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTransform;
    public Transform platformTransform;
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

        float lastPlatformY = 0f;
        foreach (Transform child in platformTransform)
        {
            lastPlatformY = Mathf.Max(lastPlatformY, child.position.y);
        }

        foreach (Transform child in platformTransform)
        {
            if (cameraTransform.position.y > (child.position.y + 6f))
            {
                float newX = Random.Range(-5.0f, 5.0f);
                Vector3 newPosition = new Vector3(newX, lastPlatformY + 6f, 0);
                child.position = newPosition;
            }
        }
    }
}
