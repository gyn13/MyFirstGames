using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scorePlayer;
    public int scoreEnemy;
    
    [Header("Text Display")]
    [SerializeField] private Text counterPlayer;
    [SerializeField] private Text counterEnemy;

    void Update()
    {
        counterPlayer.text = scorePlayer.ToString();
        counterEnemy.text = scoreEnemy.ToString();
    }
}
