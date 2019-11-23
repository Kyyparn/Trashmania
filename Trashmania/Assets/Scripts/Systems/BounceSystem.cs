using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class BounceSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation) =>
        {
            translation.Value.y = Mathf.Sin((float)Time.ElapsedTime);
        });
    }
}
