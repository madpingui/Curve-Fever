using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasEnded = false;

    public TextMeshProUGUI scorePlayer1, scorePlayer2;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        scorePlayer1.text = PlayerPrefs.GetInt("Player1").ToString();
        scorePlayer2.text = PlayerPrefs.GetInt("Player2").ToString();
        if(PlayerPrefs.GetInt("Player1") == 10 || PlayerPrefs.GetInt("Player2") == 10)
        {
            PlayerPrefs.DeleteAll();
            scorePlayer1.text = "0";
            scorePlayer2.text = "0";
        }
    }

    public void EndGame()
    {
        if (hasEnded)
            return;

        hasEnded = true;
        StartCoroutine(PlayEndGameAnimation());
    }

    IEnumerator PlayEndGameAnimation()
    {
        //AnimationDeath

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
