using System.Collections.Generic;

namespace BuilderPattern;

public interface IBicycleProduct
{
    public IFrame Frame { get; set; }
    public ISuspension Suspension { get; set; }
    public IHandlebars Handlebars { get; set; }
    public IDrivetrain Drivetrain { get; set; }
    public ISeat Seat { get; set; }
    public IBrakes Brakes { get; set; }
}
