using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public Sprite[] _Sprite_Array;

    /// <summary>
    /// Stores Scenes as Int array - Int Element passed is build Index reference of scene
    /// </summary>
    public int[] _Scene_Array;


    //
    public Animator _Animator;

    //IMG Used To Identify Scene Change Option

    public GameObject _LevelSelect;
    private int _LevelSelected = 0;
    public int _LevelNum = 0;
    //OnClick Reference , When clicked with show next "Sprite" Level Identifying Image
    private void Update()
    {
        _LevelNum = Mathf.Clamp(_LevelNum, 0, 2);
    }
    public void NextLevel()
    {
        _LevelNum++;
        //Element Access stops at 4 (0 - 4 / 5 Levels)
        if (_LevelNum == 0)
        {
           // _LevelNum = 1;
            _LevelSelect.GetComponent<Image>().sprite = _Sprite_Array[_LevelNum];
        }
        else if(_LevelNum == 1)
        {
            //Increments to get then show next level
            //_LevelNum = 2;
            _LevelSelect.GetComponent<Image>().sprite = _Sprite_Array[_LevelNum];
        }
        else if(_LevelNum == 2)
        {
            //_LevelNum = 3;
            _LevelSelect.GetComponent<Image>().sprite = _Sprite_Array[_LevelNum];
        }
        //Based off input , current image shown is level selected option,  if "StartLevel" is clicked its based from this option to access element correctly.
        _LevelSelected = _LevelNum;
    }


    //OnClick Reference , When clicked with show previous "Sprite" Level Identifying Image

    public void PreviousLevel()
    {
        _LevelNum--;
        //Element Access Can go below 0
        if (_LevelNum == 0)
        {
            //_LevelNum = 1;

            _LevelSelect.GetComponent<Image>().sprite = _Sprite_Array[_LevelNum];
        }
        else if (_LevelNum == 1)
        {
            //Increments to get then show next level
            //_LevelNum = 2;
            _LevelSelect.GetComponent<Image>().sprite = _Sprite_Array[_LevelNum];
        }
        else if (_LevelNum == 2)
        {
            //_LevelNum = 3;
            _LevelSelect.GetComponent<Image>().sprite = _Sprite_Array[_LevelNum];
        }
        _LevelSelected = _LevelNum;
    }

    //OnClick Reference , When clicked will Load chosen scene
    public void StartLevel()
    {


        StartCoroutine(LoadLevel());

    }
    IEnumerator LoadLevel()
    {
        _Animator.SetTrigger("StartTransition");

        yield return new WaitForSeconds(1);
        //Elements 0 - 4 in both arrays are ordered the same , e.g level 1 = 0 (for both arrays) ect...
        SceneManager.LoadScene(_Scene_Array[_LevelSelected]);

    }
}
