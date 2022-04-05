using System;
using System.Collections.Generic;
using UnityEngine;

public class WagonPartManager : MonoBehaviour
{
    [SerializeField]
    private WagonStatus wagonStatus;
    public WagonStatus Status => wagonStatus;

    public event Action OnPartAdded;

    [SerializeField]
    private List<PartStatus> parts;

    [SerializeField]
    private Transform next;

    public Transform Next => next;

    [SerializeField]
    private GameObject backWall;
    
    [ContextMenu("Add Part")]
    public void AddPart() {
        if(parts.Count == 0) return;

        var part = parts.GetRandom();
        part.gameObject.SetActive(true);
        parts.Remove(part);
        wagonStatus.Parts.Add(part);
        OnPartAdded?.Invoke();
    }

    public void SetLast(bool last){
        if (last) {
            backWall.SetActive(true);
        } else {
            backWall.SetActive(false);
        }
    }

    public int PartsLeft => parts.Count;

}
