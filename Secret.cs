using System.Xml.Linq;

namespace Foodie
{
    public class Secret
    {
        private string _password = "Test1234!";    // input the password value here
        public string Password   // property
        {
            get { return _password; }   // get method
        }
    }
}
