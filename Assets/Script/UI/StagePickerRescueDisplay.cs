using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePickerRescueDisplay : MonoBehaviour {

    public Text _CityNumTxt, _EgyptNumTxt, _PHistorictNumTxt;/*_PreHistoricNumTxt, _IceAgeNumTxt, _FutureNumTxt;*/
    public int _CityGetTtlPnts, _EgyptGetpyTtlPnts, _HistoricPhTtlPnts;
   

    void Start() 
    {
        _CityGetTtlPnts = PlayerPrefs.GetInt("TotalRescuePoints");
        _EgyptGetpyTtlPnts = PlayerPrefs.GetInt("pyTotalRescuePoints");
        _HistoricPhTtlPnts = PlayerPrefs.GetInt("phTotalRescuePoints");

        _CityNumTxt.text = "" + _CityGetTtlPnts;
        _EgyptNumTxt.text = "" + _EgyptGetpyTtlPnts;
        _PHistorictNumTxt.text = "" + _HistoricPhTtlPnts;
    }
	
}
