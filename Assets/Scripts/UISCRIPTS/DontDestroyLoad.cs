using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// 
/// Used for not destroying the targeted field/object upon loading a new scene.
/// 
/// Reasons - Mitigates Startup data field entries (certain values however may need to be reset)
/// 
/// 
/// 
/// 
/// 
/// </summary>

public class DontDestroyLoad : MonoBehaviour
{

    public void DontDestroy(string object_name)
    {


        GameObject game_object = GameObject.FindGameObjectWithTag(object_name);

        DontDestroyOnLoad(game_object);

    }



}
