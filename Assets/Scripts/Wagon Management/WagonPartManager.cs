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
    
    [ContextMenu("Add Part")]
    public void AddPart() {
        if(parts.Count == 0) return;

        var part = parts.GetRandom();
        part.gameObject.SetActive(true);
        parts.Remove(part);
        wagonStatus.Parts.Add(part);
        OnPartAdded?.Invoke();
    }

    public int PartsLeft => parts.Count;

}
