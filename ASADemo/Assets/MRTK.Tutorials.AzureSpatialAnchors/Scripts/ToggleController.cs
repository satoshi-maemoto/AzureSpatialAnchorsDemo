// Copyright (c) 2020 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.ComponentModel;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ToggleController : MonoBehaviour
{
    private Interactable interactableObj;
    private TextMesh textObj;

    public string ToggleOffText = "Off";

    [Description("Setting to this text at checked toogle switch ")]
    public string ToggleOnText = "On";

    public string ToggleDisabledText = "NotSelectable";


    public bool IsToggleOn => interactableObj.CurrentDimension == 1;

    public void SetToggleActive(bool enabled)
    {
        interactableObj.enabled = enabled;
    }

    public void SetToggleState(bool check)
    {
        if (check)
        {
            interactableObj.CurrentDimension = 1;
        }
        else
        {
            interactableObj.CurrentDimension = 0;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        interactableObj = GetComponent<Interactable>();
        textObj = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!interactableObj.enabled)
        {
            textObj.text = ToggleDisabledText;
            return;
        }
        if (IsToggleOn)
        {
            textObj.text = ToggleOnText;
        }
        else
        {
            textObj.text = ToggleOffText;
        }
    }
}