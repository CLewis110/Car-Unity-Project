using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Labeler : MonoBehaviour
{
    public Text _text;

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void ClearText()
    {
        _text.text = "";
    }
}
