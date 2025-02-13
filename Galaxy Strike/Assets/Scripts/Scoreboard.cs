using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreboardText;
    public void IncreaseScore(int amount)
    {
        score += amount;
        // TODO memo
        scoreboardText.text = score.ToString();
        Debug.Log(score);
    }
}
