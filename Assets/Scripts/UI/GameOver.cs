using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _gameOverPanel;

    private void Start()
    {
        _player.Dying += OnPlayerDying;
    }

    private void OnPlayerDying()
    {
        _gameOverPanel.Play("down");
    }

    private void OnDisable()
    {
        _player.Dying -= OnPlayerDying;
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
