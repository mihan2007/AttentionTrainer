using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float _xField = 650;
    private const float _yField = 300;
    private int i;


    [SerializeField] private GameObject _popUpWindow;
    [SerializeField] private TMP_Text _popUpWindowLable;

    [SerializeField] static  int GlobalCounter;
    
    [SerializeField] private Image _progressBar;

    [SerializeField] private Slider _timeSlider;
    [SerializeField] private Slider _amountSlider;

    [SerializeField] private TMP_Text _timeSliderLable;
    [SerializeField] private TMP_Text _amountSliderLable;

    [SerializeField] private float _gameTime;
    [SerializeField] private float _amountFishka;

    [SerializeField] private bool _isGameStarted;

    [SerializeField] private TMP_Text _difficutyLable;
    [SerializeField] private bool _isStartButtonPressed;
    [SerializeField] private Fishka _fishka;
    [SerializeField] private GameObject _fishkaRoot;




    private void Start()
    {
        _difficutyLable.text = "Difficulty";
    }

    private void Update()
    {
        if (!_isGameStarted)
        {
            _gameTime = _timeSlider.value;
            _amountFishka = _amountSlider.value;

            _timeSliderLable.text = _timeSlider.value.ToString("F2");
            _amountSliderLable.text = _amountSlider.value.ToString("F0");
        }
       else
        {
            float _progressBarHigh;
            float _progressBarMaxLenght = 1280;
                       
            if (_gameTime >= 0)
            {
                _gameTime -= Time.deltaTime;
                _difficutyLable.text = "Started";
                _timeSliderLable.text = _gameTime.ToString("F2");
                _timeSlider.interactable = false;

                float _progressBarCurrantLenght = _progressBarMaxLenght * (_gameTime / _timeSlider.value);

                _progressBarHigh = _progressBar.rectTransform.rect.height;

                _progressBar.rectTransform.sizeDelta = new Vector2(_progressBarCurrantLenght, _progressBarHigh);
            }
            
            if (_gameTime <= 0)
            {
                _isGameStarted = false;
                _popUpWindow.SetActive(true);
                _popUpWindowLable.text = "GAME OVER";
                _difficutyLable.text = "Difficulty";
                _timeSlider.interactable = true;
            }
        }
    }

    public void CreatFishkaOnClick()
    {
        if (!_isStartButtonPressed)
        {
            _isStartButtonPressed = true;
            _isGameStarted = true;          

            for (i = 1; i <= _amountFishka; i++)
            {
                Fishka newFishka = Instantiate(_fishka, _fishkaRoot.transform);
                newFishka.transform.localPosition = new Vector3(Random.Range(-_xField, _xField), Random.Range(-_yField, _yField), 0);
                newFishka.transform.localRotation = Quaternion.identity;
                newFishka.init(i);
            }
        } 
    }

    public void CheckGlobalCounter(int number)
    {
        
    }

    public void ClosePopUpWindow()
    {
        GameObject[] FishkaClone = GameObject.FindGameObjectsWithTag("Fishka");
        foreach (GameObject prefab in FishkaClone)
        {
            Destroy(prefab);
        }
        
        _popUpWindow.SetActive(false);
        _isStartButtonPressed = false;

    }
}