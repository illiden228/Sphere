using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private float _timeToNextSpawn = 0;
    private int _currentWaveNumber;

    void Start()
    {
        _currentWaveNumber = 0;
        SetWave(_currentWaveNumber);
        _timeToNextSpawn = _currentWave.TimeBetweenSpawn;
        _player.Dying += Close;
        _player.MoneyChanged += NextWave;
    }

    void Update()
    {        
        _timeToNextSpawn -= Time.deltaTime;
        if(_timeToNextSpawn < 0)
        {
            Instantiate(_currentWave.Template);
            _timeToNextSpawn = _currentWave.TimeBetweenSpawn;
        }
    }

    private void SetWave(int number)
    {
        _currentWave = _waves[number];
        Debug.Log(number);
    }

    private void NextWave(int playerMoneys)
    {
        Debug.Log(playerMoneys);
        Debug.Log(_currentWave.MoneysCountForNextWave);
        if(playerMoneys == _currentWave.MoneysCountForNextWave)
        {
            Debug.Log("Next");
            if (_currentWaveNumber < _waves.Length - 1)
            {
                SetWave(++_currentWaveNumber);
            }
        }
    }

    private void Close()
    {
        enabled = false;
    }
}

[System.Serializable]
class Wave
{
    public GameObject Template;
    public int MoneysCountForNextWave;
    public float TimeBetweenSpawn;
}
