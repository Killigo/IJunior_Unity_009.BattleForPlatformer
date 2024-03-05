using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : Bar
{
    [SerializeField] private Image _bar;
    [SerializeField] private Gradient _gradientBar;
    [SerializeField] private Text _text;

    private readonly float _duration = 0.7f;

    protected override void OnHealthChanged(float currentValue, float maxValue)
    {
        float value = currentValue / maxValue;
        _bar.DOFillAmount(value, _duration);
        _bar.color = _gradientBar.Evaluate(value);
        _text.text = $"{Mathf.Round(currentValue)}/{Mathf.Round(maxValue)}";
    }
}
