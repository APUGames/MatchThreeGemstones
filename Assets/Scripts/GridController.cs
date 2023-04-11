using System;
using UnityEngine;


public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject gemBlue;
    [SerializeField]
    private GameObject gemPurp;
    [SerializeField]
    private GameObject gemRed;
    [SerializeField]
    private GameObject gemGreen;
    [SerializeField]
    private GameObject gemYellow;
    [SerializeField]
    private GameObject gemOrange;


    [SerializeField]
    private Vector3 originPosition;

    public bool pressedDown;
    public Vector2 pressedDownPosition;
    public GameObject pressedDownGameObject;
    public Vector2 pressedUpPosition;
    public GameObject pressedUpGameObject;

    private Vector2 startMovementPiecePosition;
    private Vector2 endMovementPiecePosition;

    public bool validMoveInProcess = false;

    [Header("UI")]
    [SerializeField]
    private GameObject matchesFoundText;

    private int matchesFound;

    // This script will manage the grid of pieces
    private Piece[,] grid = new Piece[8, 8];

    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                Vector3 newWorldPosition = new Vector3(originPosition.x + row, originPosition.y, originPosition.z - column);

                //grid[row, column] = new Piece(newWorldPosition, new Vector2(row, column));

                Piece newPiece = new Piece(newWorldPosition, new Vector2(row, column)); 

                System.Random rand = new System.Random();

                int randomNum = rand.Next(1, 90);

                if (randomNum >= 1 && randomNum < 15)
                {
                    Instantiate(gemBlue, grid[row, column].GetPosition(), Quaternion.identity);
                }
                else if (randomNum >= 15 && randomNum < 30)
                {
                    Instantiate(gemPurp, grid[row, column].GetPosition(), Quaternion.identity);

                }
                else if (randomNum >= 30 && randomNum < 45)
                {
                    Instantiate(gemRed, grid[row, column].GetPosition(), Quaternion.identity);

                }
                else if (randomNum >= 45 && randomNum < 60)
                {
                    Instantiate(gemGreen, grid[row, column].GetPosition(), Quaternion.identity);

                }
                else if (randomNum >= 60 && randomNum < 75)
                {
                    Instantiate(gemYellow, grid[row, column].GetPosition(), Quaternion.identity);

                }
                else if (randomNum >= 75 && randomNum < 90)
                {
                    Instantiate(gemOrange, grid[row, column].GetPosition(), Quaternion.identity);

                }

                grid[row, column] = newPiece;

            }

        }

    }


    // Update is called once per frame
    void Update()
    {
        if (validMoveInProcess)
        {
            Vector3 placeHolderPosition = pressedDownGameObject.transform.position;
            pressedDownGameObject.transform.position = pressedUpGameObject.transform.position;
            pressedUpGameObject.transform.position = placeHolderPosition;


            Piece placeHolderPiece = grid[(int)endMovementPiecePosition.x, (int)endMovementPiecePosition.y];
            grid[(int)endMovementPiecePosition.x, (int)endMovementPiecePosition.y] = grid[(int)startMovementPiecePosition.x, (int)startMovementPiecePosition.y];
            grid[(int)startMovementPiecePosition.x, (int)startMovementPiecePosition.y] = placeHolderPiece;

            validMoveInProcess = false;

            matchesFound += 1;
        }
    }

    public void ValidMove(Vector2 start, Vector2 end)
    {
        Debug.Log("validating start (" + start.x + ", " + start.y + ") | end (" + end.x + ", " + end.y + ")");
        startMovementPiecePosition = start;
        endMovementPiecePosition = end;

        bool matchFound = false;

        if (!matchFound)
        {
            try
            {
                Piece topPiece1 = grid[(int)end.x, (int)end.y - 1];
                Piece bottomPiece1 = grid[(int)end.x, (int)end.y + 1];
                Debug.Log("Top piece type: " + topPiece1.GetPieceType());
                Debug.Log("Bottom piece type: " + bottomPiece1.GetPieceType());
                Piece midPiece1 = grid[(int)start.x, (int)start.y];
                Piece toDestroy1 = grid[(int)end.x, (int)end.y];
                Debug.Log("Mid piece type: " + midPiece1.GetPieceType());
                if (topPiece1.GetPieceType() == bottomPiece1.GetPieceType())
                {
                    if (topPiece1.GetPieceType() == midPiece1.GetPieceType())
                    {
                        matchFound = true;
                        validMoveInProcess = true;
                        topPiece1.SetForDestruction();
                        bottomPiece1.SetForDestruction();
                        toDestroy1.SetForDestruction();
                        Debug.Log("It Work");
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        Debug.Log("No move fore you");
    }

    public bool IsDestroyed(Vector2 gridPosition)
    {
        Piece piece = grid[(int)gridPosition.x, (int)gridPosition.y];
        return piece.GetDestruction();
    }
}

