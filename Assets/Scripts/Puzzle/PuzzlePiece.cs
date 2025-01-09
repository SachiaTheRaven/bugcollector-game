using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : Interactable
{
    [SerializeField] private int id;
    public override void Interact()
    {
        FindObjectOfType<GameManager>().AddPiece(id);
    }

}
