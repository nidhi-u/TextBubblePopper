using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _scoreText;  

    [SerializeField] private PointsManager _pointsManager;

    void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _pointsManager = FindObjectOfType<PointsManager>();
        _pointsManager.OnPointsUpdated += UpdateScoreDisplay;
        _scoreText.text = "Stress-o-meter: " + _pointsManager.GetPoints().ToString() + "%";
    }

    // Method to update the score text on screen
    void UpdateScoreDisplay()
    {
        _scoreText.text = "Stress-o-meter: " + _pointsManager.GetPoints().ToString() + "%";
    }

    void OnDestroy()
    {
        if (_pointsManager != null)
        {
            _pointsManager.OnPointsUpdated -= UpdateScoreDisplay;
        }
    }
}
