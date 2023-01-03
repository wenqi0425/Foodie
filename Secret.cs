using System.Xml.Linq;

namespace Foodie
{
    public class Secret
    {
        private string _password = "Your Password";    // input the password value here
        public string Password   // property
        {
            get { return _password; }   // get method
        }
    }
}
