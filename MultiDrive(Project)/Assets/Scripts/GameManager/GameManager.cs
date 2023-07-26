using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CurrentLevel { get; private set; }

    public void SetCurrentLevel(int level) => CurrentLevel = level;
}