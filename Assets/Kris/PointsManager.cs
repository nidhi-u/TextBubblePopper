using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int _points;
    [SerializeField]
    private int _increment = 10;
    [SerializeField]
    private int _multiplier = 1;
    [SerializeField]
    private int _max = 100;

    public delegate void PointsUpdatedHandler();
    public event PointsUpdatedHandler OnPointsUpdated;

    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
    }

    void UpdatePoints(int value)
    {
        _points += value;
        OnPointsUpdated?.Invoke();
    }

    public void ModifyPoints(bool increase)
    {
        int changeAmount = increase ? _increment : -_increment;
        UpdatePoints(_multiplier* changeAmount);
    }

    public int GetPoints()
    {
        return _points;
    }

    public int GetMax()
    {
        return _max;
    }
}
