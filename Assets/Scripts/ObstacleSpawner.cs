using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacleTemplate;
    [SerializeField] private float _timeBetweenSpawn = 1;
    [SerializeField] private Player _player;
    private float _timeToNextSpawn = 0;

    void Start()
    {
        _timeToNextSpawn = _timeBetweenSpawn;
        _player.OnDie += Close;
    }

    void Update()
    {        _timeToNextSpawn -= Time.deltaTime;
        if(_timeToNextSpawn < 0)
        {
            Instantiate(_obstacleTemplate);
            _timeToNextSpawn = _timeBetweenSpawn;
        }
    }

    private void Close()
    {
        enabled = false;
    }
}
