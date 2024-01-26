using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _position;
    private float _zCameraPosition = -10f;

    private void Update()
    {
        _position = _player.transform.position;
        _position.z = _zCameraPosition;
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}
