using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> ChangeableObjects;
    private List<IChangeable> _ChangeableObj = new List<IChangeable>();
    // Update is called once per frame

    private void Start()
    {
        for(int i = 0; i < ChangeableObjects.Count; i++)
        {
            var changeableObjects = ChangeableObjects[i].GetComponent<IChangeable>();
            _ChangeableObj.Add(changeableObjects);
        }


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for(int i = 0; i < _ChangeableObj.Count; i++)
            {
                _ChangeableObj[i].Next();
            }

        }
    }
    
}

public interface IChangeable
{
    void Next();
}
