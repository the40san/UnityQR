using UnityEngine.UI;

namespace FortyWorks.QR
{
    public class QRCodeImage : RawImage
    {
        public void UpdateImageWithContent(string content)
        {
            var qrMaker = new QRMaker(content);
            this.texture = qrMaker.CreateImage();
        }
    }
}