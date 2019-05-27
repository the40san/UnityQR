using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace FortyWorks.QR
{
    [CustomEditor(typeof(QRCodeImage))]
    public class QRCodeImageEditor : RawImageEditor
    {
        public string testString = "";
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.Label("ExportTest");
            testString = GUILayout.TextField(testString, 140);

            if (GUILayout.Button("TwitterPostUrlTest"))
            {
                var image = target as QRCodeImage;
                var twitterPostUrl = new TwitterPreparePostUrl(testString);
                
                if (image != null) image.UpdateImageWithContent(twitterPostUrl.ToString());
            }
        }
    }
}