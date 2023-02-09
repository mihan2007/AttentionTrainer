using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int ProgressBarMaxLenght = 1280;
    private const float XField = 650;
    private const float YField = 300;

    [SerializeField] private GameObject _popUpWindow;
    [SerializeField] private TMP_Text _popUpWindowLable;

    [SerializeField] private Image _progressBar;

    [SerializeField] private Slider _timeSlider;
    [SerializeField] private Slider _amountSlider;

    [SerializeField] private TMP_Text _timeSliderLable;
    [SerializeField] private TMP_Text _amountSliderLable;

    [SerializeField] private float _gameTime;
    [SerializeField] private int _amountFishka;

    [SerializeField] private bool _isGameStarted;

    [SerializeField] private TMP_Text _difficutyLable;
    [SerializeField] private bool _isStartButtonPressed;
    [SerializeField] private Fishka _fishka;
    [SerializeField] private GameObject _fishkaRoot;



    private int _globalCounter;
    private int _i;

    private void Start()
    {
        _timeSlider.onValueChanged.AddListener(OnChangeTimeSliderValue);
        _timeSlider.onValueChanged.AddListener(OnChangeAmountSliderValue);
    }
    private void OnChangeTimeSliderValue(float newValue)
    {
        _timeSliderLable.text = _timeSlider.value.ToString("F2");
    }

    private void OnChangeAmountSliderValue(float newValue)
    {
        _amountSliderLable.text = _amountSlider.value.ToString("F0");
    }
    private void Update()
    {
        if (!_isGameStarted)
        {
            return;
        }
        if (_gameTime <= 0)
        {
            GameOver();
            return;
        }

        CalculateTime();        

    }
    
    private void CalculateTime()
    {
        
        float progressBarHigh;

        if (_gameTime >= 0)
        {
            _gameTime -= Time.deltaTime;
            _difficutyLable.text = "Started";
            _timeSliderLable.text = _gameTime.ToString("F2");
            _timeSlider.interactable = false;

            float _progressBarCurrantLenght = ProgressBarMaxLenght * (_gameTime / _timeSlider.value);

            progressBarHigh = _progressBar.rectTransform.rect.height;

            _progressBar.rectTransform.sizeDelta = new Vector2(_progressBarCurrantLenght, progressBarHigh);
        }
    }

    public void CreatFishkaOnClick()
    {
        _gameTime = _timeSlider.value;
        _amountFishka = (int)_amountSlider.value;

        if (!_isStartButtonPressed)
        {
            _isStartButtonPressed = true;
            _isGameStarted = true;          

            for (_i = 1; _i <= _amountFishka; _i++)
            {
                Fishka newFishka = Instantiate(_fishka, _fishkaRoot.transform);
                newFishka.transform.localPosition = new Vector3(Random.Range(-XField, XField), Random.Range(-YField, YField), 0);
                newFishka.transform.localRotation = Quaternion.identity;
                newFishka.init(_i,this);
            }
        } 
    }

    public void CheckGlobalCounter(int number)
    {

        
        if (_globalCounter != number -1)
        {
            GameOver();
            return;
        }
        
        _globalCounter++;

        if (_globalCounter == _amountFishka)
        {
            Win();
        }
    }

    public void ClosePopUpWindow()
    {
        GameObject[] fishkaClone = GameObject.FindGameObjectsWithTag("Fishka");
        foreach (GameObject prefab in fishkaClone)
        {
            Destroy(prefab);
        }
        
        _popUpWindow.SetActive(false);
        _isStartButtonPressed = false;

    }
    public void GameOver()
    {
        _isGameStarted = false;
        _popUpWindow.SetActive(true);
        _popUpWindowLable.text = "GAME OVER";
        _difficutyLable.text = "Difficulty";
        _timeSlider.interactable = true;
        _globalCounter = 0;
    }
    public void Win()
    {
        _isGameStarted = false;
        _popUpWindow.SetActive(true);
        _popUpWindowLable.text = "YOU WIN";
        _difficutyLable.text = "Difficulty";
        _timeSlider.interactable = true;
        _globalCounter = 0;

    }
}