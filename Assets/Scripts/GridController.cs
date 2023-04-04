using System;
using UnityEngine;


public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject gemBlue;
    [SerializeField]
    private GameObject gemPurp;
    [SerializeField]
    private GameObject gemPink;
    [SerializeField]
    private GameObject gemGreen;
    [SerializeField]
    private GameObject gemYellow;
    [SerializeField]
    private GameObject gemOrange;
    //instandiating for differnt positions of prefabs does not work unfortunately


    [SerializeField]
    private Vector3 originPosition;

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

                grid[row, column] = new Piece(newWorldPosition, new Vector2(row, column));

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
                    Instantiate(gemPink, grid[row, column].GetPosition(), Quaternion.identity);

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


            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
