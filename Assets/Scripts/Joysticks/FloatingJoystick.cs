using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TouchState
{
    k_NoTouch = 0,
    k_Touching,
    k_TouchRelease,
}

public class FloatingJoystick : Joystick
{
    public TouchState state;

    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
        state = TouchState.k_NoTouch;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        state = TouchState.k_Touching;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        state = TouchState.k_TouchRelease;
    }
}