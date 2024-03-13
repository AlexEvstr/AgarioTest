using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    //public float ScoreEditor = 1000f;

    private void Start()
    {
        InvokeRepeating("UpdateScore", 1, 1);
    }

    private void UpdateScore()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        float score = 0f;

        for (int i = 0; i < player.Length; i++)
        {
            score += player[i].transform.localScale.x * 100;
        }

        _scoreText.text = $"Score: {score.ToString("f0")}";
    }
}
