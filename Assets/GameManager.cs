using UnityEngine;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

// GameManager class
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Difficulty currentDifficulty = Difficulty.Easy;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void changedifficulty(Difficulty NewDifficulty)
    {
        currentDifficulty = NewDifficulty;
    }
}


