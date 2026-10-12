using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TMP_Text scoreUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        scoreUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    public void UpdateScore(PlayerController scoreHolder)
    {
        scoreUI.text = $"Score: {scoreHolder.score}";
    }
}
