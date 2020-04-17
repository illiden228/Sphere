using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _moneyTemplate;

    private Wave _currentWave;
    private Transform _currentSpawnPoint;
    private float _timeToNextSpawn = 0;
    private int _currentWaveNumber;

    void Start()
    {
        _currentWaveNumber = 0;
        SetWave(_currentWaveNumber);
        _player.Dying += Close;
        _player.MoneyChanged += NextWave;
    }

    void Update()
    {        
        _timeToNextSpawn -= Time.deltaTime;
        if(_timeToNextSpawn < 0)
        {
            SetSpawnPoint(Random.Range(0, _spawnPoints.Length));
            CreateObstacle();
            FillMoney();
            _timeToNextSpawn = _currentWave.TimeBetweenSpawn;
        }
    }

    private GameObject CreateObstacle()
    {
        return Instantiate(_currentWave.Template, _currentSpawnPoint);
    }

    private void FillMoney()
    {
        foreach(var spawnPoint in _spawnPoints)
        {
            if (spawnPoint != _currentSpawnPoint)
            {
                Instantiate(_moneyTemplate, spawnPoint);
            }
        }
    }

    private void SetWave(int number)
    {
        _currentWave = _waves[number];
    }

    private void NextWave(int playerMoneys)
    {
        if(playerMoneys == _currentWave.MoneysCountForNextWave)
        {
            if (_currentWaveNumber < _waves.Length - 1)
            {
                SetWave(++_currentWaveNumber);
            }
        }
    }

    private void SetSpawnPoint(int number)
    {
        _currentSpawnPoint = _spawnPoints[number];
    }

    private void Close()
    {
        _player.Dying -= Close;
        _player.MoneyChanged -= NextWave;
        Destroy(gameObject);
    }
}

[System.Serializable]
class Wave
{
    public GameObject Template;
    public int MoneysCountForNextWave;
    public float TimeBetweenSpawn;
}
