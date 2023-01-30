using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fishka : MonoBehaviour
{
    [SerializeField] private TMP_Text _indexNumber;

    public void init(int Index)
    {
        _indexNumber.text = Index.ToString("F0");
    }

    public void DestroyOnClick()
    {
        Destroy(gameObject);
    }
}
