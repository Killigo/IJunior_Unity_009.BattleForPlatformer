using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _wayPoints;
    private int _currentPoint;

    private void Awake()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _wayPoints[i] = _path.GetChild(i);
    }

    public Transform GetNextPosition()
    {
        _currentPoint = (_currentPoint + 1) % _wayPoints.Length;

        return _wayPoints[_currentPoint];
    }
}
