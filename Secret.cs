using System.Xml.Linq;

namespace Foodie
{
    public class Secret
    {
        private string _password = "Foodie1234!";
        public string Password   // property
        {
            get { return _password; }   // get method
        }
    }
}
