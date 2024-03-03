using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _offsetPosition;

    private Vector3 _position;
    private float _zCameraPosition = -10f;

    private void Update()
    {
        _position = _player.transform.position;
        _position.y = _player.transform.position.y + _offsetPosition;
        _position.z = _zCameraPosition;
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}
