using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float _xField = 650;
    private const float _yField = 300;
    private int i;
    
    [SerializeField] private bool isStartButtonPressed;
    [SerializeField] private Fishka _fishka;
    [SerializeField] private GameObject _fishkaRoot;

    public void CreatFishkaOnClick()
    {
        if (isStartButtonPressed == false)
        {
            isStartButtonPressed = true;

            for (i = 1; i <= 10; i++)
            {
                Fishka newFishka = Instantiate(_fishka, _fishkaRoot.transform);
                newFishka.transform.localPosition = new Vector3(Random.Range(-_xField, _xField), Random.Range(-_yField, _yField), 0);
                newFishka.transform.localRotation = Quaternion.identity;
                newFishka.init(i);
            }
        } 
    }
}