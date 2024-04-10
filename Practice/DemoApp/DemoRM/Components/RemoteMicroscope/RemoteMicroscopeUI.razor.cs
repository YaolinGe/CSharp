using DemoRM.Components.RemoteMicroscope.Models;
using Microsoft.AspNetCore.Components;


public partial class RemoteMicroscopeUI
{
    private List<RemoteMicroscope>? remoteMicroscopes;
    private RemoteMicroscopeDatabase? remoteMicroscopeDatabase;

    private async Task AddRemoteMicroscope(RemoteMicroscope remoteMicroscope)
    {
        await remoteMicroscopeDatabase.AddRemoteMicroscopeAsync(remoteMicroscope);
        remoteMicroscopes = await remoteMicroscopeDatabase.GetAllRemoteMicroscopesAsync();
    }

    private async Task DeleteRemoteMicroscope(int id)
    {
        await remoteMicroscopeDatabase.DeleteRemoteMicroscopeAsync(id);
        remoteMicroscopes = await remoteMicroscopeDatabase.GetAllRemoteMicroscopesAsync();
    }

    //Handle UI event here

}

