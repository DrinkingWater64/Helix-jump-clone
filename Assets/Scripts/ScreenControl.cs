using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _prevPos = Vector3.zero;
    private Vector3 _posDelta = Vector3.zero;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationDamping;
    [SerializeField] private float _rotationVelocity;
    private bool _dragged;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rotationVelocity = eventData.delta.x * _rotationSpeed;
        transform.Rotate(Vector3.up, -_rotationVelocity, Space.Self);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragged = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_dragged && !Mathf.Approximately(_rotationVelocity, 0))
        {
            float deltaVelocity = Mathf.Min(
                Mathf.Sign(_rotationVelocity)*Time.deltaTime*_rotationDamping,
                Mathf.Sign(_rotationVelocity)*_rotationVelocity
                );
            _rotationVelocity -= deltaVelocity;
            transform.Rotate(Vector3.up, -_rotationVelocity, Space.Self);
        }
    }
}