using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager sInstance;

    public static ScoreManager Instance
    {
        get
        {
            return sInstance;
        }
    }

    public int score;
    public int showScore;
    private int delta;
    public ScoreText scoreText;
    public Text text;

    void Awake()
    {
        sInstance = this;
        score = 0;
        showScore = 0;
    }

    void Update()
    {
        text.text = score.ToString();
        if (showScore < score)
        {
            int mount = delta / 10;
            showScore += mount;
            if (showScore >= score)
            {
                showScore = score;
            }
        }
        scoreText.score = showScore;
    }

    public void AddScore(int number)
    {
        score += number;
        delta = score - showScore;
    }
}