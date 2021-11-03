using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Data Manager is null");
            }

            return _instance;
        }
    }

    private int _randNum;
    public int EvenOddNumber
    {
        get
        {
            return _randNum;
        }
    }

    private TileData[] _tileDatas;

    [System.Serializable]
    public struct TileData
    {
        public int _tileNumber;
        public int _tileColor;
    }

    private void Awake()
    {
        _instance = this;
    }

    public void GenerateData(int numberOfData)
    {
        _randNum = Random.Range(1, 3);
        _tileDatas = new TileData[numberOfData];
        int num = 0;

        for(int i = 0; i < numberOfData; i++)
        {
            switch (_randNum)
            {
                case 1:
                    num += _randNum;
                    break;
                case 2:
                    num += _randNum;
                    break;
            }
            _tileDatas[i]._tileNumber = num;
            _tileDatas[i]._tileColor = Random.Range(0, 8);
        }

       
        SaveManager.Save(_tileDatas);
    }
}
