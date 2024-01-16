using System.Text;

namespace BuilderPattern;

public class BicycleProduct : IBicycleProduct
{
    public IFrame Frame { get; set; }
    public ISuspension Suspension { get; set; }
    public IHandlebars Handlebars { get; set; }
    public IDriventrain Drivetrain { get; set; }
    public ISeat Seat { get; set; }
    public IBrakes Brakes { get; set; }

    public override string ToString()
    {
        var fullDescription = new StringBuilder("Here's your new bicycle: ");
 
        fullDescription.AppendLine(Frame.ToString());
        fullDescription.AppendLine(Suspension.ToString());
        fullDescription.AppendLine(Handlebars.ToString());
        fullDescription.AppendLine(Drivetrain.ToString());
        fullDescription.AppendLine(Seat.ToString());
        fullDescription.AppendLine(Brakes.ToString());
        return fullDescription.ToString();
    }
}
