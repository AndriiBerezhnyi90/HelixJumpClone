using UnityEngine;
using System.Collections.Generic;

public class HelixGenerator : MonoBehaviour
{
    [SerializeField] private Helix _template;
    [SerializeField,Range(2f,10)] private int _helixAmount;

    private List<Helix> _helixs = new List<Helix>();
    private float _distanceBetweenHelixs = 2f;

    private void Start()
    {
        CreateHelixs();
    }

    private void CreateHelixs()
    {
        var helix = Instantiate(_template, transform);
        helix.CreateFirsHelix();
        _helixs.Add(helix);
    }
}