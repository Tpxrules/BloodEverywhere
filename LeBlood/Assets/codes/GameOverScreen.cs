
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
       [SerializeField] public TextMeshProUGUI text2;

  public void Setup(int score){
    PauseGame();
    if(score>staticinfo.HS)
    staticinfo.HS = score;
    gameObject.SetActive(true);
    text.text = "Score : "+score.ToString();
      text2.text = staticinfo.HS.ToString();
  }

}
