using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class DataToSave
{

	// Use this for initialization
	void Start ()
    {
        FileManager.SaveData<DataToSave>(this, Application.dataPath + "SavedShit.xml");

        DataToSave loadedData = FileManager.LoadData<DataToSave>(Application.dataPath + "SavedShit.xml");

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
