using System.Net;

namespace RemoteMicroscope.Components;

public partial class ImageFetcher
{
    private string imageByteString = "";

    private void CaptureImage()
    {
        using (var client = new WebClient())
        {
            client.Proxy = null;

            // client.DownloadFile("http://138.103.116.99:5000/camera/0", "image.jpg");
            // var imageBytes = client.DownloadData("http://138.103.116.99:5000/camera/0"); 
            // var imageBytes = client.DownloadData("http://127.0.0.1:5000/camera/0");
            // var imageBytes = client.DownloadData("http://localhost:3000");
            // client.DownloadFile("http://localhost:5000/camera/0", "wwwroot/image.jpg");
            client.DownloadFile("http://138.103.116.98:5000/camera/0", "wwwroot/image.jpg");
            // client.DownloadFile("https:hips.hearstapps.com/hmg-prod/images/little-cute-maltipoo-puppy-royalty-free-image-1652926025.jpg", "wwwroot/image.jpg");

            Console.WriteLine("Image downlaoded");
            System.Diagnostics.Debug.WriteLine("Image downloaded");

            var imageBytes = File.ReadAllBytes("wwwroot/image.jpg");
            imageByteString = "data:image/jpeg;base64, " + Convert.ToBase64String(imageBytes);

            //StateHasChanged();
        }
    }
}

