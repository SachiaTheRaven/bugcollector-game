using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideyPlace : Interactable
{
    [SerializeField] private BugTypes hiddenBugType;
    private bool turned = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite turnedSprite;
    // Start is called before the first frame update
    void Start()
    {
        SetupBugType();
    }

    public override void Reveal()
    {
        TurnRock();
        //todo play animation
    }
    public override void Interact()
    {
        if (turned && hiddenBugType != BugTypes.NONE)
        {
            hiddenBugType = BugTypes.NONE;
            TurnRock();
        }
    }
    public override bool CanInteract()
    {
        return turned;
    }
    public BugTypes RevealBugType() { return hiddenBugType; }

    private void SetupBugType()
    {
        hiddenBugType = (BugTypes)Random.Range(0, 4); //todo make constant?
    }
    private void TurnRock()
    {
        turned = !turned;
        spriteRenderer.sprite = turned ? turnedSprite : normalSprite;
    }
}
