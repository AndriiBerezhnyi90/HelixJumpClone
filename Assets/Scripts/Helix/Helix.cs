using UnityEngine;
using System.Collections.Generic;

public class Helix : MonoBehaviour
{
    [SerializeField] private GoodPart _goodPart;
    [SerializeField] private BadPart _badPart;
    [SerializeField] private FinalPart _finalPart;

    private const int MaxPartsAmount = 12;
    private int _goodPartAmount = 8;
    private int _badPartAmount = 1;
    private Vector3 _startRotation = new Vector3(-90, 30, 0);
    private float _angleStep = 30;
    private List<float> _availableAngles = new List<float>();

    private void Start()
    {
        for (int i = 0; i < MaxPartsAmount; i++)
        {
            _availableAngles.Add(_startRotation.y);
            _startRotation.y += _angleStep;
        }

        CreatePartsRandom();
    }

    public void CreateFirsHelix()
    {
        CreatePart(_goodPart, 0);
        CreatePart(_goodPart, _availableAngles.Count - 1);
        CreatePartsRandom();
    }

    public void CreatePartsRandom()
    {
        int position;
      
        for (int i = 0; i < _goodPartAmount; i++)
        {
            position = Random.Range(0, _availableAngles.Count);
            CreatePart(_goodPart,position);
        }

        for (int i = 0; i < _badPartAmount; i++)
        {
            position = Random.Range(0, _availableAngles.Count);
            CreatePart(_badPart,position);
        }
    }

    public void CreateFinalHelix()
    {
        for (int i = 0; i < MaxPartsAmount; i++)
        {
            CreatePart(_finalPart, i);
        }
    }

    private void CreatePart(HelixPart part,int position)
    {
        var template = Instantiate(part, transform);
        _startRotation.y = _availableAngles[position];
        template.transform.localEulerAngles = _startRotation;
        _availableAngles.RemoveAt(position);

        if (part is GoodPart)
            _goodPartAmount--;
        else if (part is BadPart)
            _badPartAmount--;
    }
}