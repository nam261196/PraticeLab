using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainCharecterObject
{
    protected int Health =0;
    protected int BomCount =0;

    virtual public void AddBom()
    {
        Debug.Log("Invoke from abstract");
        BomCount++;
    }

    virtual public void UseBom()
    {
        Debug.Log("Invoke from abstract");
        BomCount--;
    }
    public abstract int SetHealth
    {
        get;
        set;
    }

}
public class testing
{

}