using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GsmrUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Hight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.SetText(GameManager.instance.getScore().ToString());
        Hight.SetText(GameManager.instance.getScore().ToString());
    }
  public  void Menu() {
        SceneManager.LoadScene("Menu");
    }

}
