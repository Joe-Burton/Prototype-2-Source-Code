using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private ManagePuzzleGame puzzleGameManager;

    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        puzzleGameManager = FindObjectOfType<ManagePuzzleGame>(); // Find the ManagePuzzleGame script
    }

    public void Drag()
    {
        print("Dragging");
        //GameObject.Find("image").transform.position = Input.mousePosition;
        gameObject.transform.position = Input.mousePosition;

        //Original:
        //GameObject.Find("image").transform.position = Input.mousePosition;
        //print("Dragging" + gameObject.name);
    }

    public void Drop()
    {
        CheckMatch();
        puzzleGameManager.CheckWinCondition(); // Check win condition after dropping the piece
    }

    public void CheckMatch()
    {
        GameObject img = gameObject;
        string tag = gameObject.tag;
        GameObject ph = GameObject.Find("PH" + tag);
        float distance = Vector3.Distance(ph.transform.position, img.transform.position);
        if (distance <= 50)
        {
            Snap(img, ph);
        }
        else
        {
            MoveBack();
        }
    }

    public void MoveBack()
    {
        transform.position = originalPosition;
    }

    public void Snap(GameObject img, GameObject ph)
    {
        img.transform.position = ph.transform.position;
        puzzleGameManager.PiecePlaced();
    }
    
    public void initCardPosition() 
    {
        originalPosition = transform.position; 
    }
}