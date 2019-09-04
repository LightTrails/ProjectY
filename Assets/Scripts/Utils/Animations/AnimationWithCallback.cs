using System;

public class AnimationWithCallback : IAnimation
{
    private readonly Action callBackBefore;
    private readonly Action callBackAfter;
    private bool hasBeenCalledBack = false;
    private readonly IAnimation animation;


    public static AnimationWithCallback Create(
        IAnimation animation, 
        Action callBackBefore = null,
        Action callbackAfter = null) => new AnimationWithCallback(animation, callBackBefore, callbackAfter);

    public AnimationWithCallback(IAnimation animation, Action callBackBefore, Action callBackAfter){
        this.callBackBefore = callBackBefore;
        this.callBackAfter = callBackAfter;
        this.animation = animation;
    }

    public bool Update(float deltaTime)
    {
        if(!hasBeenCalledBack){
            hasBeenCalledBack = true;
            if(this.callBackBefore != null){
                this.callBackBefore();
            }
        }

        if(this.animation.Update(deltaTime)){
            if(this.callBackAfter != null){
                this.callBackAfter();
            }
            
            return true;
        }

        return false;
    }
}