using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public GameObject effect;

    public void OnHit()
    {
        SoundManager.coinCheck = true;
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
