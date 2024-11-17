using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSelectionResponse : MonoBehaviour, ISelectionResponse
{
    private bool CanPlay = true;
    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<AudioSource>();
        if (selectionRenderer != null)
        {
            if (CanPlay)
            {
                CanPlay = false;
               StartCoroutine(Play(selectionRenderer));
            }


        }
    }
    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<AudioSource>();
        if (selectionRenderer != null)
        {


        }
    }
    public IEnumerator Play(AudioSource a)
    {
        CanPlay = false;
        a.PlayOneShot(a.clip);
        yield return new WaitForSeconds(4f);
        a.Stop();
        CanPlay = true;
    }
}
