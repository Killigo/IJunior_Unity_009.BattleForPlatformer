using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private CharacterHealth _character;

    private void OnEnable()
    {
        _character.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= OnHealthChanged;
    }

    protected abstract void OnHealthChanged(float currentValue, float maxValue);
}
