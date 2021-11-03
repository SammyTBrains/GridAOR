using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static GridManager _instance;
    public static GridManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Grid Manager is null!");
            }

            return _instance;
        }
    }

    [SerializeField]
    private int _xDim;
    [SerializeField]
    public GameObject tilePrefab;

    private int _yDim;
    private DataManager.TileData[] _tileDatas;
    private Color[] _tileColors = { Color.black, Color.blue, Color.red, Color.cyan, Color.green, Color.yellow, Color.magenta, Color.gray };

    private GameObject _container;
    public GameObject Container
    {
        get
        {
            return _container;
        }
    }

    private int t = 0;
    public int T
    {
        get
        {
            return t;
        }

        set
        {
            t = value;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void CreateGrid()
    {
        _tileDatas = SaveManager.Load();
        _container = new GameObject("Container");
        if (UIManager.Instance.NumberOfTiles != 0)
        {
            switch (UIManager.Instance.NumberOfTiles)
            {
                case 84:
                    _yDim = -539;
                    break;
                case 63:
                    _yDim = -227;
                    break;
                case 42:
                    _yDim = 85;
                    break;
                case 21:
                    _yDim = 397;
                    break;
            }
        }
        else
        {
            switch (_tileDatas.Length)
            {
                case 84:
                    _yDim = -539;
                    break;
                case 63:
                    _yDim = -227;
                    break;
                case 42:
                    _yDim = 85;
                    break;
                case 21:
                    _yDim = 397;
                    break;
            }
        }
        for (int x = -342; x < _xDim; x += 104)
        {
            for (int y = 605; y >= _yDim; y -= 104)
            {
                GameObject tPfb = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                AssignTileData(tPfb);
                _container.transform.SetParent(transform, false);
                tPfb.transform.SetParent(_container.transform, false);
            }
        }
        t = 0;
    }

    private void AssignTileData(GameObject tPfb)
    {
        if (t < _tileDatas.Length)
        {
            Tile tile = tPfb.GetComponent<Tile>();
            tile.TileNumber = _tileDatas[t]._tileNumber;
            tile.TileColor = _tileColors[_tileDatas[t]._tileColor];
            t++;
        }
    }
}
