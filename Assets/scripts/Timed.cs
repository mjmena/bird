using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Timed{
    private float lifetime;
    private Stopwatch timer;

    public Timed(float lifetime){
        timer = new Stopwatch();
        timer.Start();
        this.lifetime = lifetime;
    }

    public bool IsElapsed(){
        return (lifetime - timer.ElapsedMilliseconds) < 0;
    }
}
