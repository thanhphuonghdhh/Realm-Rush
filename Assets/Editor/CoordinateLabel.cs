using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro _textMeshPro;
    Vector2Int _position = new Vector2Int();
    Waypoint waypoint;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    private void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        _textMeshPro = GetComponent<TextMeshPro>();
        _textMeshPro.enabled = false; 
        DisplayCoordinate();
    }
    void Update()
    {
        if (!Application.isPlaying) //only executed in edit mode
        {
            DisplayCoordinate();
            UpdateObjectName(); 
            _textMeshPro.enabled = false; 
        }
        SetColorLabel();
        ToggleLabel();
    }

    void DisplayCoordinate()
    {
        //UnityEditor.EditorSnapSettings.move.y = 10 (size of a grid)
        _position.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        _position.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
        _textMeshPro.text = _position.x + " " + _position.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = _position.ToString();
    }
    void SetColorLabel()
    {
        if (waypoint.IsPlaceable) { _textMeshPro.color = defaultColor; }
        else _textMeshPro.color = blockedColor;
    }
    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _textMeshPro.enabled = ! _textMeshPro.enabled;
        }
    }
}
