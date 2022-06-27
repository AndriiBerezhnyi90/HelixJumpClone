using UnityEngine;
using System.Collections.Generic;

public class HelixGenerator : MonoBehaviour
{
    [SerializeField] private Helix _template;
    [SerializeField,Range(2f,10)] private int _helixAmount;
    [SerializeField] private float _distanceBetweenHelixs = 2f;

    private Queue<Helix> _helixs = new Queue<Helix>();

    private void Start()
    {
        CreateHelixs();
        SetHelixs();
    }

    private void CreateHelixs()
    {
        for (int i = 0; i < _helixAmount; i++)
        {
            var helix = Instantiate(_template, transform);
            _helixs.Enqueue(helix);
        }
    }

    private void SetHelixs()
    {
        Vector3 currentPostion = transform.position;
        _helixs.Peek().transform.position = currentPostion;
        _helixs.Dequeue().CreateFirsHelix();
        currentPostion.y -= _distanceBetweenHelixs;

        while (_helixs.Count > 1)
        {
            _helixs.Peek().transform.position = currentPostion;
            _helixs.Dequeue().CreatePartsRandom();
            currentPostion.y -= _distanceBetweenHelixs;
        }

        _helixs.Peek().transform.position = currentPostion;
        _helixs.Dequeue().CreateFinalHelix();
    }
}