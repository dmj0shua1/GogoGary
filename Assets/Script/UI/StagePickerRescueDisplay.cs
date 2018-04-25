using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePickerRescueDisplay : MonoBehaviour {

    public Text _CityNumTxt, _EgyptNumTxt, _PHistorictNumTxt, _IceAgeNumTxt, _FutureNumTxt;/*_PreHistoricNumTxt, _IceAgeNumTxt, _FutureNumTxt;*/
    public int _CityGetTtlPnts, _EgyptGetpyTtlPnts, _HistoricPhTtlPnts, _IceAGeIeTtlPnts, _FutureFcTtlPnts;
   

    void Start() 
    {
        _CityGetTtlPnts = PlayerPrefs.GetInt("TotalRescuePoints");
        _EgyptGetpyTtlPnts = PlayerPrefs.GetInt("pyTotalRescuePoints");
        _HistoricPhTtlPnts = PlayerPrefs.GetInt("phTotalRescuePoints");
        _IceAGeIeTtlPnts = PlayerPrefs.GetInt("ieTotalRescuePoints");
        _FutureFcTtlPnts = PlayerPrefs.GetInt("ftTotalRescuePoints");

        _CityNumTxt.text = "" + _CityGetTtlPnts;
        _EgyptNumTxt.text = "" + _EgyptGetpyTtlPnts;
        _PHistorictNumTxt.text = "" + _HistoricPhTtlPnts;
        _IceAgeNumTxt.text = "" + _IceAGeIeTtlPnts;
        _FutureNumTxt.text = "" + _FutureFcTtlPnts;
    }
	
}
