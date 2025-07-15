using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dp;
    public Difficulty LevelSelected;

    void Start()
    {
           LevelSelected = Difficulty.Easy;
    }
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelChange()
    {
        int LVLindex = dp.value;
        if (LVLindex == 0)
        {
            LevelSelected = Difficulty.Easy;
            Debug.Log("Easy Selected");
        }
        else if (LVLindex == 1)
        {
            LevelSelected = Difficulty.Normal;
            Debug.Log("Normal Selected");
        }
        else
        {
            LevelSelected = Difficulty.Hard;
            Debug.Log("Hard Selected");
        }
    }
    public void QuitGame()
    {
        Debug.Log("Game Closed Using Main Menu");
        Application.Quit();
    }
}
