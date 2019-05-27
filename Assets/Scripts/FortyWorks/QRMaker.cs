using UnityEngine;
using ZXing;
using ZXing.QrCode;

namespace FortyWorks.QR
{
    public class QRMaker
    {
        public enum QRImageResolution
        {
            SIZE_128 = 7,
            SIZE_256,
            SIZE_512,
            SIZE_1024,
            SIZE_2048,
            SIZE_4096
        }

        private readonly int _size;
        private readonly string _content;

        public QRMaker(string content, QRImageResolution resolution = QRImageResolution.SIZE_128)
        {
            _size = (int) Mathf.Pow(2, (int)resolution);
            _content = content;
        }

        public Texture2D CreateImage()
        {
            return CreateQrCode(_content, _size, _size);
        }
        
        private static Texture2D CreateQrCode(string str, int w, int h)
        {
            var tex = new Texture2D(w, h, TextureFormat.ARGB32, false);
            var content = Write(str, w, h);
            tex.SetPixels32(content);
            tex.Apply();
            return tex;
        }

        private static Color32[] Write(string content, int w, int h)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = w,
                    Height = h
                }
            };
            return writer.Write(content);
        }
    }
}