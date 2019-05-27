using System.Web;

namespace FortyWorks.QR
{
    public class TwitterPreparePostUrl
    {
        private readonly string _baseUrl = "https://twitter.com/intent/tweet?text=";
        private readonly string _content;
        
        public TwitterPreparePostUrl(string content)
        {
            _content = content;
        }

        public override string ToString()
        {
            return $"{_baseUrl}{HttpUtility.UrlEncode(_content)}";
        }
    }
}