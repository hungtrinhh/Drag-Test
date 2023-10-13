using UnityEngine;

public class ObserverTest : MonoBehaviour
{
    
    
    private void Start()
    {
        Draggable.OnParentChange += OnChangeParent;
    }

    private void OnDestroy()
    {
        Draggable.OnParentChange -= OnChangeParent;
    }

    public void OnChangeParent()
    {
        Debug.Log("ParentChange");
    }
}