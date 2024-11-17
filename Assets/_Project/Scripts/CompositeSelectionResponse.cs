using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    [SerializeField] private GameObject selectionResponseHolder;
    private List<ISelectionResponse> _SelectionResponses;
    private int _currIndex;
    private Transform _selection;

    public void Start()
    {
        var selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>();
        _SelectionResponses = selectionResponses.ToList();
    }
    public void Next()
    {
        _SelectionResponses[_currIndex].OnDeselect(_selection);
        _currIndex = (_currIndex + 1) % _SelectionResponses.Count;
        _SelectionResponses[_currIndex].OnSelect(_selection);
    }
    public void OnDeselect(Transform selection)
    {
        _selection = null;
        if (HasSelection())
        {
            _SelectionResponses[_currIndex].OnDeselect(selection);
        }

    }

    public void OnSelect(Transform selection)
    {
        _selection = selection;
        if (HasSelection())
        {
            _SelectionResponses[_currIndex].OnSelect(selection);
        }

    }
    private bool HasSelection()
    {
        return _currIndex > -1 && _currIndex < _SelectionResponses.Count;
    }
}
