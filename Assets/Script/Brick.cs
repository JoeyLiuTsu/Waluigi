using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject effect;

    public void OnHit()
    {
        SoundManager.brickCheck = true;
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
