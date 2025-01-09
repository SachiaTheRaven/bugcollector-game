using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ghost : Interactable
{
    [SerializeField] private BugTypes faveBugType;
    [SerializeField] private int bugsNeeded;
    [SerializeField] private GameObject hintGraphic;
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private GameObject ghostGraphic;
    [SerializeField] private GameObject puzzlePiecePrefab;
    // Start is called before the first frame update
 
    public override bool CanInteract()
    {
        return bugsNeeded > 0;
    }
    public override void Interact()
    {
        bugsNeeded--;
        if(bugsNeeded == 0)
        {
            Instantiate(puzzlePiecePrefab);
            var randomOffset = Random.insideUnitCircle;
            puzzlePiecePrefab.transform.position = transform.position + new Vector3(randomOffset.x,randomOffset.y,0);
            hintText.text = bugsNeeded.ToString();
        }
    }
    public override void Reveal()
    {
        hintGraphic.SetActive(true);
        hintText.text = bugsNeeded.ToString();
    }
    public bool WantsBug(BugTypes bug)
    {
        return bug == faveBugType;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ghostGraphic.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ghostGraphic.SetActive(false);
            hintGraphic.SetActive(false);
        }
    }
}
