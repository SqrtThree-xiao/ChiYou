using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[LuaCallCSharp]
public class LuaComponent : MonoBehaviour {

	public LuaTable luaTable;

    //lua常用函数
	LuaFunction luaAwake;
	LuaFunction luaStart;
	LuaFunction luaOnEnable;
	LuaFunction luaOnDisable;
	LuaFunction luaUpdate;
	LuaFunction luaOnDestroy;
	LuaFunction luaFixedUpdate;
	LuaFunction luaLateUpdate;


    //lua路径，不用填缀名，可以是bundle
    [Tooltip("script path")]
    public string LuaPath;


	public static LuaTable Add(GameObject go,LuaTable tableClass)
    {
        LuaFunction luaCtor =  tableClass.Get<LuaFunction>("ctor");
        if ( null != luaCtor)
        {
            object[] rets = luaCtor.Call(tableClass);
            if (1 != rets.Length)
            {
                return null;
            }
            LuaComponent cmp = go.AddComponent<LuaComponent>();
            cmp.luaTable = (LuaTable)rets[0];
            cmp.initLuaFunction();
            cmp.CallAwake();
            return cmp.luaTable;
        }
        else
        {
            throw new Exception("Lua function .ctor not found");
        }
    }

	public static LuaTable Get(GameObject go,LuaTable table)
    {
        LuaComponent[] cmps =   go.GetComponents<LuaComponent>();
        string tableStr = table.ToString();
        for(int i = 0; i < cmps.Length;i++)
        {
            string temp = cmps[i].luaTable.ToString();
            if(string.Equals(tableStr,cmps[i].luaTable.ToString()))
            {
                return cmps[i].luaTable;
            }
        }
        return null;
        
    }

	public static void SetParent(GameObject go,Transform parent)
    {
        go.transform.SetParent(parent);
    }

	void initLuaFunction()
    {
        luaOnDestroy =  luaTable.Get<LuaFunction>("OnDestroy");
        luaAwake = luaTable.Get<LuaFunction>("Awake");
        luaStart = luaTable.Get<LuaFunction>("Start");
        luaUpdate = luaTable.Get<LuaFunction>("Update");
        luaOnEnable = luaTable.Get<LuaFunction>("OnEnable");
        luaFixedUpdate = luaTable.Get<LuaFunction>("FixedUpdate");
        luaOnDisable = luaTable.Get<LuaFunction>("OnDisable");
        luaLateUpdate = luaTable.Get<LuaFunction>("LateUpdate");
    }

	void CallAwake()
    {
        if ( null != luaAwake)
        {
            luaAwake.Call(luaTable, gameObject);
        }
    }

	private void Start()
    {
        if ( null != luaStart)
        {
            luaStart.Call(luaTable, gameObject);
        }
    }

	private void Update()
    {
        if (null != luaUpdate)
        {
            luaUpdate.Call();
        }
    }

	private void FixedUpdate()
    {
        if (null != luaFixedUpdate)
        {
            luaFixedUpdate.Call();
        }
    }

	private void OnDestroy()
    {
        if (null != luaOnDestroy)
        {
            luaOnDestroy.Call();
        }
    }

	private void OnEnable()
    {
        if (null != luaOnEnable)
        {
            luaOnEnable.Call();
        }
    }
	private void OnDisable()
    {
        if (null != luaOnDisable)
        {
            luaOnDisable.Call();
        }
    }

    private void LateUpdate()
    {
        if (null != luaLateUpdate)
        {
            luaLateUpdate.Call();
        }
    }
}
