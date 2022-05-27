using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroan : MonoBehaviour
{
    public AudioClip zombieGroanOne;
    public AudioClip zombieGroanTwo;
    public AudioClip zombieGroanThree;

    private AudioClip currentClip;

    public List<AudioClip> ZombieGroanList = new List<AudioClip>();
    public bool isPlaying = false;
    // Start is called before the first frame update
    public void Start()
    {
        ZombieGroanList.Add(zombieGroanOne);
        ZombieGroanList.Add(zombieGroanTwo);
        ZombieGroanList.Add(zombieGroanThree);
        Debug.Log(ZombieGroanList.Count);
    }

    // Update is called once per frame
   public void Update()
   {

        if (isPlaying == false)
        {
            StartCoroutine(ZombieGroan());
        }
   }

    IEnumerator ZombieGroan()
    {
        isPlaying = true;
        float random = Random.Range(0f, 11f);
        yield return new WaitForSeconds(random);
        currentClip = ZombieGroanList[Random.Range(0, ZombieGroanList.Count)];
        AudioSystem.PlaySoundEffect(currentClip);
        yield return new WaitForSeconds(3f);
        isPlaying = false;
    }
}
