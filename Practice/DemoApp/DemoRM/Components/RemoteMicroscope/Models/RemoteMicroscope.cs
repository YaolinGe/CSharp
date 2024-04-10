namespace DemoRM.Components.RemoteMicroscope.Models;


public class RemoteMicroscope
{
    public int Id { get; set; }
    public string IPAddress { get; set; }
    public int PortNumber { get; set; } 

    //public bool IsActive { get; set; }
    public string Name { get; set; }
}
