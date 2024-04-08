using System.Net;

namespace DemoRM.Components.Pages
{
    public partial class RemoteMicroscope
    {
        


        private string imageByteString = "";

        private void CaptureImage()
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;

                client.DownloadFile("http://138.103.116.98:5000/camera/0", "wwwroot/image.jpg");

                Console.WriteLine("Image downloaded");
                System.Diagnostics.Debug.WriteLine("Image downloaded");

                var imageBytes = File.ReadAllBytes("wwwroot/image.jpg");
                imageByteString = "data:image/jpeg;base64, " + Convert.ToBase64String(imageBytes);
            }
        }
    }
}
