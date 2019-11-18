using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class LuaComponent : MonoBehaviour {

    public SGTextAsset luaFile;

    void Start()
    {
        if (luaFile != null)
        {
            LuaEvnManager.Instance.RunLuaCode(luaFile.Text);
        }
    }
}
