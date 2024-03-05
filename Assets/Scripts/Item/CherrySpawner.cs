using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    [SerializeField] private CollectableItem _prefab;

    private Transform[] _points;

    private void Start()
    {
        _points = GetComponentsInChildren<Transform>();

        var random = Random.Range(1, _points.Length);

        Instantiate(_prefab, _points[random].transform.position, _points[random].transform.rotation);
    }
}
