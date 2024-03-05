using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private CollectableItem _prefab;

    private Transform[] _points;

    private void Start()
    {
        _points = GetComponentsInChildren<Transform>();

        for (int i = 1; i < _points.Length; i++)
        {
            Instantiate(_prefab, _points[i].transform.position, _points[i].transform.rotation);
        }
    }
}
