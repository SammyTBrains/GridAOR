using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Text _tileNumberText;
    [SerializeField]
    private Image _spriteImage;

    private int _tileNumber;
    public int TileNumber
    {
        get
        {
            return _tileNumber;
        }

        set
        {
            _tileNumber = value;
        }
    }

    private Color _tileColor;
    public Color TileColor
    {
        set
        {
            _tileColor = value;
        }
    }

    public void TileData()
    {
        Tile[] tiles = GameObject.FindObjectsOfType<Tile>();
        DisplayData();
        int numF = _tileNumber;
        int numB = _tileNumber;
        for (int i = 1; i <= UIManager.Instance.AreaOfInterest; i++)
        {
            switch (DataManager.Instance.EvenOddNumber)
            {
                case 1:
                    numF += 1;
                    numB -= 1;
                    break;
                case 2:
                    numF += 2;
                    numB -= 2;
                    break;
            }
            
            for (int t = 0; t < tiles.Length; t++)
            {
                if (tiles[t].TileNumber == numF || tiles[t].TileNumber == numB)
                {
                    tiles[t].DisplayData();
                }
            }
        }
    }

    public void DisplayData()
    {
        _spriteImage.color = _tileColor;
        _tileNumberText.gameObject.SetActive(true);
        _tileNumberText.text = _tileNumber.ToString();
    }
}
