using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ColorChange : MonoBehaviour 
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _highlightColor;

    void OnSelectEnter() { _text.color = _highlightColor; }
    void OnSelectExit() { _text.color = _normalColor; }
}
