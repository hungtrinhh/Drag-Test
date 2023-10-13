
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropable : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Drop " + transform.name);
            Draggable.Parent = transform;
        }
        else
        {
            transform.GetChild(0).SetParent(Draggable.Parent);
            Draggable.Parent = transform;
        }
    }
}