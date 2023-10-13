using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Camera _camera;
    private Vector3 distanceFromMouse;
    public static Transform Parent;
    [SerializeField] private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        distanceFromMouse = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position
            ;
        distanceFromMouse.z = 0;
        Parent = transform.parent;
        transform.SetParent(transform.root);
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var position = _camera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position - distanceFromMouse;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(Parent);
        _image.raycastTarget = true;
    }
}