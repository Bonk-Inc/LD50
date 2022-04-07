using System;
using System.Collections.Generic;
using UnityEngine;

public class WagonPartManager : MonoBehaviour
{
    [SerializeField]
    private Wagon wagonStatus;
    public Wagon Status => wagonStatus;

    public event Action<PartStatus> OnPartAdded;

    [SerializeField]
    private List<PartStatus> parts;

    [SerializeField]
    private Transform next;

    public Transform Next => next;

    [SerializeField]
    private GameObject backWall;
    
    [ContextMenu("Add Part")]
    public void AddRandomPart() {
        if(parts.Count == 0) return;

        var part = parts.GetRandom();
        part.gameObject.SetActive(true);
        part.OnRepaired += wagonStatus.Heal;
        parts.Remove(part);
        wagonStatus.Parts.Add(part);
        OnPartAdded?.Invoke(part);
    }

    public void SetLast(bool last) {
        if(backWall != null) backWall.SetActive(last);
    }

    public int PartsLeft => parts.Count;

}
