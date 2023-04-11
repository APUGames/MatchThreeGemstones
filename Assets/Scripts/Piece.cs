using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceTypes
{
    Blue = 1,
    Purple = 2,
    Red = 3,
    Green = 4,
    Yellow = 5,
    Orange = 6
}
public class Piece
{
    private Vector3 position;
    private Vector2 gridPosition;
    private PieceTypes pieceType;
    private bool setForDestruction;

    public Piece()
    {
        position = Vector3.zero;
        gridPosition = Vector2.zero;
        setForDestruction = false;

    }

    public Piece(Vector3 position, Vector2 gridPosition)
    {
        this.position = position;
        this.gridPosition = gridPosition;
        this.setForDestruction = false;
    }
    public Piece(Vector3 position, Vector2 gridPosition, PieceTypes pieceType)
    {
        this.position = position;
        this.gridPosition = gridPosition;
        this.pieceType = pieceType;
        this.setForDestruction = false;
    }

    public void SetForDestruction()
    {
        this.setForDestruction = true;
    }

    public void SetPieceType(PieceTypes pieceType)
    {
        this.pieceType = pieceType;
    }
    public void SetGridPosition(Vector2 position)
    {
        this.gridPosition = position;
    }

    public Vector3 GetPosition()
    {
        return position;
    }

    public Vector3 GetGridPosition()
    {
        return gridPosition;
    }

    public PieceTypes GetPieceType()
    {
        return pieceType;
    }

    public bool GetDestruction()
    {
        return setForDestruction;
    }
}