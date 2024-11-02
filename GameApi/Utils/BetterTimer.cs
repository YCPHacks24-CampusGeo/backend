﻿namespace GameApi.Utils;

public class BetterTimer : System.Timers.Timer
{
    private DateTime m_dueTime;

    public BetterTimer() : base() => this.Elapsed += this.ElapsedAction;

    protected new void Dispose()
    {
        this.Elapsed -= this.ElapsedAction;
        base.Dispose();
    }

    public double TimeLeft => (this.m_dueTime - DateTime.Now).TotalMilliseconds;
    public new void Start()
    {
        this.m_dueTime = DateTime.Now.AddMilliseconds(this.Interval);
        base.Start();
    }

    private void ElapsedAction(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (this.AutoReset)
            this.m_dueTime = DateTime.Now.AddMilliseconds(this.Interval);
    }
}
