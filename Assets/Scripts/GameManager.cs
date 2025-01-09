using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int numberOfPieces;
    [SerializeField] private GameObject[] puzzlePieceIndicators;
    private GameObject[] puzzleImagePieces;
    [SerializeField] private GameObject puzzleImageParent;
    [SerializeField] private float fadeSpeed = 10;
    [SerializeField] private float fadeBreak = 2;
    private int piecesCollected = 0;
    [SerializeField] private GameObject endPanel;

    private void Start()
    {
        puzzleImagePieces=puzzleImageParent.GetComponentsInChildren<GameObject>();
    }
    public void AddPiece(int piece)
    { 
        piecesCollected++;
        puzzlePieceIndicators[piece].SetActive(true);
        puzzleImagePieces[piece].SetActive(true);
        DisplayPuzzle();
        if(piecesCollected== numberOfPieces)
        {
            EndGame();
        }
    }
    void DisplayPuzzle()
    {
        StartCoroutine(FadeInAndOut());
    }
    IEnumerator FadeInAndOut()
    {
        Time.timeScale = 0;
        puzzleImageParent.SetActive(true);
        var canvasGroup=puzzleImageParent.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        while(canvasGroup.alpha<1f)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(fadeBreak);
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        puzzleImageParent.SetActive(false);
        Time.timeScale = 1;
    }

    void EndGame()
    {
        endPanel.SetActive(false);
        Time.timeScale= 0;
        
    }
        
}
