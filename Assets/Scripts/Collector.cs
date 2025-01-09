using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private BugTypes collectedBug = BugTypes.NONE;
    private Interactable interactableInRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(interactableInRange!=null)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                interactableInRange.Reveal();
            }
            if(Input.GetKeyDown(KeyCode.E) && interactableInRange.CanInteract())
            {
                if(interactableInRange is HideyPlace hideyPlace)
                {
                    collectedBug= hideyPlace.RevealBugType();
                    hideyPlace.Interact();
                }
                if(interactableInRange is Ghost ghost && ghost.WantsBug(collectedBug))
                {
                    interactableInRange.Interact();
                    collectedBug = BugTypes.NONE;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       var interactable = collision.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactableInRange= interactable;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Interactable>()==interactableInRange) { interactableInRange = null; }
    }
    
}

