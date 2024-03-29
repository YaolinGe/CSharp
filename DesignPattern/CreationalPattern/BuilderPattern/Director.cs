﻿namespace BuilderPattern;

public class Director
{
    public Director(IBicycleBuilder builder)
    {
        builder = builder; 
    }
    private IBicycleBuilder Builder { get; set; }

    public void ChangeBuilder(IBicycleBuilder builder)
    {
        Builder = builder; 
    }

    public IBicycleProduct Make()
    {
        Builder.BuildFrame();
        Builder.BuildHandleBars();
        Builder.BuildSeat();
        Builder.BuildSuspension();
        Builder.BuildDriveTrain();
        Builder.BuildBrakes();

        return Builder.GetProduct();
    }
}
