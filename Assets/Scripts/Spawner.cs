using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _moneyTemplate;

    private Wave _currentWave;
    private Transform _currentSpawnPoint;
    private float _timeToNextSpawn = 0;
    private float _timeBetweenSpawnMoneys = 0;
    private float _delayBetweenWaves = 0;
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
        _timeBetweenSpawnMoneys -= Time.deltaTime;
        _timeToNextSpawn -= Time.deltaTime;
        _delayBetweenWaves -= Time.deltaTime;
        if(_delayBetweenWaves < 0)
        {
            if (_timeBetweenSpawnMoneys < 0)
            {
                if (_timeToNextSpawn < 0)
                {
                    SetSpawnPoint(Random.Range(0, _spawnPoints.Length));
                    CreateTemplateGeneratedObject(_currentWave.Template, _currentSpawnPoint);
                    FillMoney(_currentSpawnPoint);
                    _timeToNextSpawn = _currentWave.TimeBetweenSpawn;
                }
                else
                {
                    FillMoney();
                }
                _timeBetweenSpawnMoneys = 1 / _currentWave.Speed;
            }
        }
    }

    private void CreateTemplateGeneratedObject(GameObject template, Transform position)
    {
        var generatedObject = Instantiate(template, position).GetComponent<GeneratedObject>();
        generatedObject.Init(_currentWave.Speed);
    }

    private void FillMoney(Transform blockSpawnPoint = null)
    {
        foreach(var spawnPoint in _spawnPoints)
        {
            if(spawnPoint != blockSpawnPoint)
                CreateTemplateGeneratedObject(_moneyTemplate, spawnPoint);
        }
    }

    private void SetWave(int number)
    {
        if(number != 0)
            _delayBetweenWaves = 15f / _currentWave.Speed;

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
    public float Speed;
}
