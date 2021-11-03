using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _configurePopUp, _configureButton, AOI, _startUI;
    [SerializeField]
    private Text _areaOfInterestText;
    [SerializeField]
    private GameObject[] _selected;

    private GameObject _selectedSprite;
    private bool _isSelectedNumber;
    private bool _isSelectedArea;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is null!");
            }

            return _instance;
        }
    }

    private int _numberOfTiles;
    public int NumberOfTiles
    {
        get
        {
            return _numberOfTiles;
        }
    }

    private int _areaOfInterest = 1;
    public int AreaOfInterest
    {
        get
        {
            return _areaOfInterest;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        _areaOfInterestText.text = _areaOfInterest.ToString();
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("numberOfData"))
        {
            if(PlayerPrefs.GetInt("NTiles") == 0)
            {
                DataManager.Instance.GenerateData(84);
            }
            else
            {
                DataManager.Instance.GenerateData(PlayerPrefs.GetInt("NTiles"));
            }    
        }
        else
        {
            PlayerPrefs.SetString("numberOfData", "Set");
            DataManager.Instance.GenerateData(84);
        }

        GridManager.Instance.CreateGrid();
        _startUI.SetActive(false);
        _configureButton.SetActive(true);
        AOI.SetActive(true);
    }

    public void DisplayConfigurePopUp()
    {
        _configurePopUp.SetActive(true);
        AOI.SetActive(false);
        _configureButton.SetActive(false);
    }

    public void SelectNumberOfTiles(int numberOfTiles)
    {
        if (_selectedSprite != null)
        {
            _selectedSprite.SetActive(false);
        }
        _numberOfTiles = numberOfTiles;
        _isSelectedNumber = true;
        switch (numberOfTiles)
        {
            case 21:
                _selectedSprite = _selected[0];
                break;
            case 42:
                _selectedSprite = _selected[1];
                break;
            case 63:
                _selectedSprite = _selected[2];
                break;
            case 84:
                _selectedSprite = _selected[3];
                break;
        }

        _selectedSprite.SetActive(true);
    }

    public void GenerateData()
    {
        if (_isSelectedNumber)
        {
            _isSelectedNumber = false;
            Destroy(GridManager.Instance.Container);
            _selectedSprite.SetActive(false);
            _configurePopUp.SetActive(false);
            DataManager.Instance.GenerateData(_numberOfTiles);
            GridManager.Instance.CreateGrid();
            PlayerPrefs.SetInt("NTiles", _numberOfTiles);
            AOI.SetActive(true);
            _configureButton.SetActive(true);
        }
    }

    public void SelectAreaOfInterest(int areaOfInterest)
    {
        if (_selectedSprite != null)
        {
            _selectedSprite.SetActive(false);
        }
        _areaOfInterest = areaOfInterest;
        _isSelectedArea = true;
        switch (areaOfInterest)
        {
            case 1:
                _selectedSprite = _selected[4];
                break;
            case 2:
                _selectedSprite = _selected[5];
                break;
            case 3:
                _selectedSprite = _selected[6];
                break;
            case 4:
                _selectedSprite = _selected[7];
                break;
            case 5:
                _selectedSprite = _selected[8];
                break;
        }

        _selectedSprite.SetActive(true);
    }

    public void AreaSelected()
    {
        if (_isSelectedArea)
        {
            _isSelectedArea = false;
            _selectedSprite.SetActive(false);
            _configurePopUp.SetActive(false);
            AOI.SetActive(true);
            _configureButton.SetActive(true);
        }
    }
}
