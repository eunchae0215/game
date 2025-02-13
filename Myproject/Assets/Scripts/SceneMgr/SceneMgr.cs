using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{
    [NonSerialized]
    public string AccountName;
    [NonSerialized]
    public bool Sound;

    private void Awake()
    {
        Shared.SceneMgr = this;
        DontDestroyOnLoad(this);
        //Shared.InitTableMgr(); 나중에 넣어야 함함
    }

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnExit()
    {
        Application.Quit();

        Debug.Log(" OnExit ");
    }


}
