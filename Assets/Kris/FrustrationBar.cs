using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrustrationBar : MonoBehaviour
{
    private const int MAX_FRUSTRATION_POSITION = 250;

    [SerializeField]
    private Gradient _colorGradient;
    [SerializeField]
    private LineRenderer _frustrationLine;

    [SerializeField] private PointsManager _pointsManager;

    void Start()
    {
        _frustrationLine = this.GetComponent<LineRenderer>();
        _pointsManager = FindObjectOfType<PointsManager>();
        _pointsManager.OnPointsUpdated += SetFrustrationBar;
    }

    public void SetFrustrationBar()
    {
        _frustrationLine.positionCount = 2;
        _frustrationLine.SetPosition(0, Vector3.zero);

        float targetPercentage = ((float)_pointsManager.GetPoints() / _pointsManager.GetMax());

        float currentPercentage = _frustrationLine.GetPosition(1).x/MAX_FRUSTRATION_POSITION;
        targetPercentage = Mathf.Clamp(targetPercentage, 0, MAX_FRUSTRATION_POSITION);
        StartCoroutine(AnimateFrustrationBar(currentPercentage, targetPercentage, 1f));
    }

    IEnumerator AnimateFrustrationBar(float startingPercentage, float targetPercentage, float animationTime)
    {
        animationTime = animationTime * Mathf.Abs(targetPercentage - startingPercentage);
        float timer = 0;

        while (timer < animationTime)
        {
            timer += Time.deltaTime;
            float timePercentage = timer / animationTime;
            float currentPercentage = Mathf.Lerp(startingPercentage, targetPercentage, timePercentage);
            _frustrationLine.SetPosition(1, new Vector3(currentPercentage * MAX_FRUSTRATION_POSITION, 0, 0));
            AssignColorAtPercent(currentPercentage);
            yield return null;
        }

        _frustrationLine.SetPosition(1, new Vector3(targetPercentage * MAX_FRUSTRATION_POSITION, 0, 0));
        AssignColorAtPercent(targetPercentage);

        yield return null;
    }

    void AssignColorAtPercent(float percent)
    {
        Color currentColor = _colorGradient.Evaluate(percent);
        _frustrationLine.startColor = currentColor;
        _frustrationLine.endColor = currentColor;
    }

    void OnDestroy()
    {
        if (_pointsManager != null)
        {
            _pointsManager.OnPointsUpdated -= SetFrustrationBar;
        }
    }
}