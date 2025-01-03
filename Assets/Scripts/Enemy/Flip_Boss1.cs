using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Boss1 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Enemy_V2 enemy_V2;

    void Update()
    {
        if (enemy_V2.direction.x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
