using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// HANDLES LEVEL WAVE AND ENEMY TEXT
/// </summary>
public class WaveEnemyCounter : MonoBehaviour
{
    public NewSpawnSystem SpawnScript;
    public TextMeshProUGUI _WaveText;
    public TextMeshProUGUI _EnemyCountText;

    // Update is called once per frame
    void Update()
    {

        _WaveText.text = "WAVE:" + SpawnScript.CurrentWaveNumber;
        _EnemyCountText.text = "ENEMIES REMAINING:" + SpawnScript.ZombiesCounter;

    }
}
