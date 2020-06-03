using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _panelAnimator;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenCreatorsPanel()
    {
        _panelAnimator.Play("down");
    }

    public void CloseCreatorsPanel()
    {
        _panelAnimator.Play("up");
    }
}
