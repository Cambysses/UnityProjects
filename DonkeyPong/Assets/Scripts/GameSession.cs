using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;
    [SerializeField] TextMeshProUGUI scoreText;
    public bool autoplay;
    public int score;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
