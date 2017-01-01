using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private float _scoreCount, _highScore;
    private bool _show;
    public AudioSource _scoreAudio;
    public Text score, endScore, highScore, endScoreText, highScoreText;
    GameObject restartUI;

    // Use this for initialization
    void Start() {
        restartUI = GameObject.Find("RestartUI");
        _scoreCount = 0f;
        _highScore = PlayerPrefs.GetFloat("HighScore");
        _show = true;
        score.gameObject.SetActive(false);
        restartUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        score.text = _scoreCount.ToString();
        endScore.text = _scoreCount.ToString();
        highScore.text = _highScore.ToString();

        if (_scoreCount > _highScore)
        {
            _highScore = _scoreCount;
            PlayerPrefs.SetFloat("HighScore", _highScore);
        }
    }

    public void IncreaseScore()
    {
        _scoreAudio.Play();
        _scoreCount++;
    }

    public void ToggleScoreText()
    {
        if (_show)
        {
            score.gameObject.SetActive(false);
            _show = false;
        }
        else
        {
            score.gameObject.SetActive(true);
            _show = true;
        }
    }
    public bool IsShow()
    {
        return _show;
    }

    public float GetScore()
    {
        return _scoreCount;
    }

    public void displayRestartUI()
    {
        restartUI.gameObject.SetActive(true);
    }
}
