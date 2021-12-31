using System;
using System.Collections;
using easyar;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GunController : MonoBehaviour
{
    public static GunController Instance;
    [SerializeField] private ImageTargetController _imageTargetController;
    [SerializeField] private Transform _gunParent;
    [SerializeField] private UnityEvent WhenFoundEvent;
    [SerializeField] private UnityEvent WhenLostEvent;
    [SerializeField] private GameObject _prefab; //Ball
    [SerializeField] private GameObject _parent; //Parent Of Balls 
    [SerializeField] private Transform _startPoint; // Start Create Point Position
    [SerializeField] private float _speed; // Rotation Speed
    [SerializeField] private Text _scoreText;
    private int _score = 0;
    private float _delayToChange; // Change Speed Delay 
    [SerializeField] private bool _targetState = false;
    [SerializeField] private Material _ballMateriall;

    private void Awake()
    {
        Instance = this;
        _imageTargetController.TargetFound += WhenTargetFound;
        _imageTargetController.TargetLost += WhenTargetLost;
    }

    private void Start()
    {
        StartCoroutine(ControllDelay());
        StartCoroutine(CreateBall());
    }

    private void Update()
    {
        _gunParent.transform.Rotate(0, _speed * Time.deltaTime, 0);
    }

    private void WhenTargetFound()
    {
        _targetState = true;
        WhenFoundEvent.Invoke();
    }

    private void WhenTargetLost()
    {
        _targetState = false;
        WhenLostEvent.Invoke();
    }

    public void UpdateScore()
    {
        _score++;
        _scoreText.text = _score + "";
    }

    private IEnumerator ControllDelay()
    {
        _speed = Random.Range(-20, 30);
        _delayToChange = Random.Range(1, 5);
        yield return new WaitForSecondsRealtime(_delayToChange);
        StartCoroutine(ControllDelay());
    }

    private IEnumerator CreateBall()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        if (_targetState)
        {
            Instantiate(_prefab, _startPoint.position, Quaternion.identity, _parent.transform);
        }

        StartCoroutine(CreateBall());
    }

    public void SetBallTexture(Texture texture)
    {
        _ballMateriall.SetTexture("_MainTex",texture);
    }

}
