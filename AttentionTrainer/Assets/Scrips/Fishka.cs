using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fishka : MonoBehaviour
{
    [SerializeField] private TMP_Text _indexNumber;
    private GameManager _gamemanager;
    private int _index;

    public void init(int Index, GameManager gameManager)
    {
        _indexNumber.text = Index.ToString("F0");
        _gamemanager = gameManager;
        _index = Index;
    }


    public void DestroyOnClick()
    {
        _gamemanager.CheckGlobalCounter(_index);
        Destroy(gameObject);
    }
}
