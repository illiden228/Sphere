using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _gameOverPanel;

    private void Start()
    {
        _player.Dying += GameOverPanel;
    }

    private void GameOverPanel()
    {
        _gameOverPanel.Play("down");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
