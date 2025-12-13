using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text counter;
    public int score;

    void Update() => counter.text = score.ToString();
}
