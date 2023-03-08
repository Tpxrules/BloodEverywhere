
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    void PauseGame ()
    {
        Time.timeScale = 0;
    }
public void RestartGame ()
    {
        Time.timeScale = 1;
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    public void MENUBUTTON ()
    {
        Time.timeScale = 1;
          SceneManager.LoadScene(0);
    }
    [SerializeField] public TextMeshProUGUI text;

  public void Setup(int score){
    PauseGame();
    gameObject.SetActive(true);
    text.text = "Score : "+score.ToString();
  }

}
