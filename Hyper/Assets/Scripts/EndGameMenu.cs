using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    private void Start()
    {
        scoreText.text = "Score \n" + PlayerPrefs.GetInt("CurrentScore").ToString();
        highScoreText.text = "High Score \n" + PlayerPrefs.GetInt("HighScore", 0).ToString();

    }


}
