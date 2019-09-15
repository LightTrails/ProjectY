using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimatedObject : MonoBehaviour
{    
    protected Queue<IAnimation> AnimationQueue = new Queue<IAnimation>();

    protected void UpdateAnimation(){
        if(AnimationQueue.Count == 0){
            return;
        }

        var currentAnimation = AnimationQueue.Peek();

        if(currentAnimation != null){
            if(currentAnimation.Update(Time.deltaTime)){
                AnimationQueue.Dequeue();
            }
        }
    }
}
