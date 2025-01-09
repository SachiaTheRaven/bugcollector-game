using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual bool CanInteract()
    { return false; }
    public virtual void Reveal()
    { }
    public virtual void Interact()
    { }
}
