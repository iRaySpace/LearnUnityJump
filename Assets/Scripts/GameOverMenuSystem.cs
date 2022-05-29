using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenuSystem : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = GameSystem.highestScore.ToString();
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
