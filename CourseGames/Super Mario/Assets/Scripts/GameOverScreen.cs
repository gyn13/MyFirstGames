using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void PlayAgain() => SceneManager.LoadScene("SampleScene");
}
