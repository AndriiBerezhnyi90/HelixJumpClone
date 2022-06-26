using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private float _timeScale;

    private void Start()
    {
        Time.timeScale = _timeScale;
    }
}