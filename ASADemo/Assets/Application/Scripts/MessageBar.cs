// Copyright (c) 2020 Satoshi Maemoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using TMPro;
using UnityEngine;

public class MessageBar : MonoBehaviour
{
    public TextMeshPro text;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        this.gameObject.SetActive(false);
        this.text.text = message;
        this.gameObject.SetActive(true);
    }
}
