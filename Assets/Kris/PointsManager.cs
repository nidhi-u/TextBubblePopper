using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int _points;
    [SerializeField]
    private int _increment;

    public delegate void PointsUpdatedHandler(int currentPoints);
    public event PointsUpdatedHandler OnPointsUpdated;
    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updatePoints()
    {
        _points += _increment;


    }

    public int GetPoints()
    {
        return _points;
    }
}
