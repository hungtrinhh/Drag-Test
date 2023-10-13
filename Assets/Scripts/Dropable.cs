using System;
using IState;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropable : MonoBehaviour, IDropHandler
{
    private IStateDroppable _stateDroppable;

    
    

    public void OnDrop(PointerEventData eventData)
    {
        _stateDroppable.Execute();
    }
}