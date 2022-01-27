using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveEnemyCounter : MonoBehaviour
{
    public Spawn _SpawnScriptReference;
    public TextMeshProUGUI _WaveText;
    public TextMeshProUGUI _EnemyCountText;

    // Update is called once per frame
    void Update()
    {

        _WaveText.text = "WAVE:" + _SpawnScriptReference.currentWaveNumber;
        _EnemyCountText.text = "ENEMIES REMAINING:" + _SpawnScriptReference.enemyLeftAlive;

    }
}
