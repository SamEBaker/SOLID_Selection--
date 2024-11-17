using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal class SpotlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public GameObject spotlight;
    [SerializeField] public Vector3 offset = new Vector3(0,3,0);

    public void OnDeselect(Transform selection)
    {
            spotlight.SetActive(false);

    }

    public void OnSelect(Transform selection)
    {
        spotlight.transform.position = selection.transform.position + offset;
        spotlight.SetActive(true);
    }
}
