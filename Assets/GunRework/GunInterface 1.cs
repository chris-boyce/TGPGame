using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IGun
{
    
    void Fire();
    public int returnAmmo();
    public int returnMaxAmmo();
}