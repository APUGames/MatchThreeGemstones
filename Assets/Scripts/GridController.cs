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
        pressedDown = false;

        System.Random rand = new System.Random();
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                Vector3 newWorldPosition = new Vector3(originPosition.x + row, originPosition.y, originPosition.z - column);
                Piece newPiece = new Piece(newWorldPosition, new Vector2(row, column));
                GameObject gameObject = Instantiate(piecePrefab, newPiece.GetPosition(), Quaternion.identity);


                int randomNum = rand.Next(1, 90);

                if (randomNum >= 1 && randomNum < 15)
                {
                    GameObject pieceGameObject = Instantiate(gemBlue, newPiece.GetPosition(), Quaternion.identity);
                    newPiece.SetPieceType(PieceTypes.Blue);

                    PieceController controller = pieceGameObject.GetComponent<PieceController>();
                    controller.SetPiece(newPiece);
                }
                else if (randomNum >= 15 && randomNum < 30)
                {
                    GameObject pieceGameObject = Instantiate(gemPurp, newPiece.GetPosition(), Quaternion.identity);

                    newPiece.SetPieceType(PieceTypes.Purple);

                    PieceController controller = pieceGameObject.GetComponent<PieceController>();
                    controller.SetPiece(newPiece);
                }
                else if (randomNum >= 30 && randomNum < 45)
                {
                    GameObject pieceGameObject = Instantiate(gemRed, newPiece.GetPosition(), Quaternion.identity);

                    newPiece.SetPieceType(PieceTypes.Red);

                    PieceController controller = pieceGameObject.GetComponent<PieceController>();
                    controller.SetPiece(newPiece);
                }
                else if (randomNum >= 45 && randomNum < 60)
                {
                    GameObject pieceGameObject = Instantiate(gemGreen, newPiece.GetPosition(), Quaternion.identity);

                    newPiece.SetPieceType(PieceTypes.Green);

                    PieceController controller = pieceGameObject.GetComponent<PieceController>();
                    controller.SetPiece(newPiece);
                }
                else if (randomNum >= 60 && randomNum < 75)
                {
                    GameObject pieceGameObject = Instantiate(gemYellow, newPiece.GetPosition(), Quaternion.identity);

                    newPiece.SetPieceType(PieceTypes.Yellow);

                    PieceController controller = pieceGameObject.GetComponent<PieceController>();
                    controller.SetPiece(newPiece);
                }
                else if (randomNum >= 75 && randomNum < 90)
                {
                    GameObject pieceGameObject = Instantiate(gemOrange, newPiece.GetPosition(), Quaternion.identity);

                    newPiece.SetPieceType(PieceTypes.Orange);

                    PieceController controller = pieceGameObject.GetComponent<PieceController>();
                    controller.SetPiece(newPiece);
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
            
            grid[(int)endMovementPiecePosition.x, (int)endMovementPiecePosition.y].SetGridPosition(endMovementPiecePosition);
            grid[(int)endMovementPiecePosition.x, (int)endMovementPiecePosition.y].SetForDestruction(true);

            grid[(int)startMovementPiecePosition.x, (int)startMovementPiecePosition.y].SetGridPosition(startMovementPiecePosition);
            grid[(int)startMovementPiecePosition.x, (int)startMovementPiecePosition.y].SetForDestruction(false);
            validMoveInProcess = false;

            matchesFound += 1;
        }
    }

    private Piece GetGridPiece(int row, int column)
    {
        Piece foundPiece;
        try
        {
            foundPiece = grid[row, column];
            if (foundPiece == null || foundPiece.GetDestruction())
            {
                return null;
            }

            return foundPiece;
        }
        catch (IndexOutOfRangeException)
        {

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        return null;
    }

    private Piece GetGridPiece(int row, int column, bool isDestroyed)
    {
        Piece foundPiece;
        try
        {
            foundPiece = grid[row, column];
            if (foundPiece == null)
            {
                return null;
            }

            if (!isDestroyed)
            {
                return null;
            }

            return foundPiece;
        }
        catch (IndexOutOfRangeException)  // CS0168
        {
            // Catch IndexOutOfRangeException when the grid is asked to retrieve a
            // piece from an unknown location.
        }

        return null;
    }

    private Piece GetGridPiece(int row, int column, bool isDestroyed)
    {
        Piece foundPiece;
        try
        {
            foundPiece = grid[row, column];
            if (foundPiece == null)
            {
                return null;
            }

            if (!isDestroyed)
            {
                return null;
            }

            return foundPiece;
        }
        catch (IndexOutOfRangeException)  // CS0168
        {
            // Catch IndexOutOfRangeException when the grid is asked to retrieve a
            // piece from an unknown location.
        }

        return null;
    }

    private void SubtractMove()
    {
        // Subtract one from turns left in the game manager
        GameManager gameManager = gameObject.GetComponent<GameManager>();
        gameManager.SubtractOneFromTurnsLeft();
    }

    private void AddMatchesFound()
    {
        // Subtract one from turns left in the game manager
        GameManager gameManager = gameObject.GetComponent<GameManager>();
        gameManager.AddOneToMatchesFound();
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
                        if (start.x != end.x)
                        {
                            matchFound = true;
                            validMoveInProcess = true;
                            topPiece1.SetForDestruction();
                            bottomPiece1.SetForDestruction();
                            toDestroy1.SetForDestruction();
                            Debug.Log("It Work :D");
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }
        if (!matchFound)
        {
            // Checking for pattern of moving up or down and having
            // two matching types on the left
            try
            {
                Piece leftPiece = GetGridPiece((int)end.x - 1, (int)end.y);
                Piece leftLeftPiece = GetGridPiece((int)end.x - 2, (int)end.y);
                Piece checkPiece1 = GetGridPiece((int)start.x, (int)start.y);
                if (leftPiece.GetPieceType() == leftLeftPiece.GetPieceType())
                {
                    if (leftPiece.GetPieceType() == checkPiece1.GetPieceType())
                    {
                        matchFound = true;
                        validMoveInProcess = true;
                        Piece toDestroy2 = grid[(int)end.x, (int)end.y];

                        leftPiece.SetForDestruction();
                        leftLeftPiece.SetForDestruction();
                        toDestroy2.SetForDestruction();
                        Debug.Log("======= MATCHED =======");
                    }
                }
            }
            catch (NullReferenceException)
            {
                // Object reference not set to an instance of an object
            }
        }

        if (!matchFound)
        {
            // Checking for pattern of moving up or down and having
            // two matching types on the right
            try
            {
                Piece rightPiece = GetGridPiece((int)end.x + 1, (int)end.y);
                Piece rightRightPiece = GetGridPiece((int)end.x + 2, (int)end.y);
                Piece checkPiece2 = GetGridPiece((int)start.x, (int)start.y);
                if (rightPiece.GetPieceType() == rightRightPiece.GetPieceType())
                {
                    if (rightPiece.GetPieceType() == checkPiece2.GetPieceType())
                    {
                        matchFound = true;
                        validMoveInProcess = true;
                        Piece toDestroy2 = GetGridPiece((int)end.x, (int)end.y);

                        rightPiece.SetForDestruction();
                        rightRightPiece.SetForDestruction();
                        toDestroy2.SetForDestruction();
                        Debug.Log("======= MATCHED =======");
                    }
                }
            }
            catch (NullReferenceException)
            {
                // Object reference not set to an instance of an object
            }
        }

        if (!matchFound)
        {
            // Checking for pattern of moving up or down and having
            // two matching types on either side
            try
            {
                Piece rightPiece = GetGridPiece((int)end.x + 1, (int)end.y);
                Piece leftPiece = GetGridPiece((int)end.x - 1, (int)end.y);
                Piece checkPiece3 = GetGridPiece((int)start.x, (int)start.y);
                if (rightPiece.GetPieceType() == leftPiece.GetPieceType())
                {
                    if (rightPiece.GetPieceType() == checkPiece3.GetPieceType())
                    {
                        // Check that the start and end are not in the same
                        // row
                        if (start.y != end.y)
                        {
                            matchFound = true;
                            validMoveInProcess = true;
                            Piece toDestroy2 = GetGridPiece((int)end.x, (int)end.y);

                            rightPiece.SetForDestruction();
                            leftPiece.SetForDestruction();
                            toDestroy2.SetForDestruction();
                            Debug.Log("======= MATCHED =======");
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                // Object reference not set to an instance of an object
            }
        }

        if (!matchFound)
        {
            // Checking for pattern of moving up, down, left, or right and having
            // two matching types below
            try
            {
                Piece belowPiece = GetGridPiece((int)end.x, (int)end.y + 1);
                Piece belowBelowPiece = GetGridPiece((int)end.x, (int)end.y + 2);
                Piece checkPiece4 = GetGridPiece((int)start.x, (int)start.y);
                if (belowPiece.GetPieceType() == belowBelowPiece.GetPieceType())
                {
                    if (belowPiece.GetPieceType() == checkPiece4.GetPieceType())
                    {
                        matchFound = true;
                        validMoveInProcess = true;
                        Piece toDestroy2 = GetGridPiece((int)end.x, (int)end.y);

                        belowPiece.SetForDestruction();
                        belowBelowPiece.SetForDestruction();
                        toDestroy2.SetForDestruction();

                        Debug.Log("======= MATCHED =======");
                    }
                }
            }
            catch (NullReferenceException)
            {
                // Object reference not set to an instance of an object
            }
        }

        if (!matchFound)
        {
            // Checking for pattern of moving up, down, left, or right and having
            // two matching types above
            try
            {
                Piece abovePiece = GetGridPiece((int)end.x, (int)end.y - 1);
                Piece aboveAbovePiece = GetGridPiece((int)end.x, (int)end.y - 2);
                Piece checkPiece4 = GetGridPiece((int)start.x, (int)start.y);
                if (abovePiece.GetPieceType() == aboveAbovePiece.GetPieceType())
                {
                    if (abovePiece.GetPieceType() == checkPiece4.GetPieceType())
                    {
                        matchFound = true;
                        validMoveInProcess = true;
                        Piece toDestroy2 = GetGridPiece((int)end.x, (int)end.y);

                        abovePiece.SetForDestruction();
                        aboveAbovePiece.SetForDestruction();
                        toDestroy2.SetForDestruction();

                        Debug.Log("======= MATCHED =======");
                    }
                }
            }
            catch (NullReferenceException)
            {
                // Object reference not set to an instance of an object
            }
        }

        SubtractMove();

        Debug.Log("No move for you");
    }

    public bool IsDestroyed(Vector2 gridPosition)
    {
        Piece piece = grid[(int)gridPosition.x, (int)gridPosition.y];
        return piece.GetDestruction();
        if (piece != null)
        {
            return piece.GetDestruction();
        }
        return false;
    }

}

