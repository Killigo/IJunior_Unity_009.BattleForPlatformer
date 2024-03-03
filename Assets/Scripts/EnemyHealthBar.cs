using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : Bar
{
    [SerializeField] private Image _bar;
    [SerializeField] private Color _color;
    [SerializeField] private Camera _mainCamera;

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _mainCamera.transform.position.y, _mainCamera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }

    protected override void OnHealthChanged(float currentValue, float maxValue)
    {
        float value = currentValue / maxValue;
        _bar.fillAmount = value;
        _bar.color = _color;
    }
}
