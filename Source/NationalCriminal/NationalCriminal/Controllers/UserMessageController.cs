using System.Web.Mvc;

namespace NationalCriminal.Controllers
{
    /// <summary>
    /// this controller response for show different types of messages
    /// error, warning and so
    /// with ability to back to the requster controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class UserMessageController : Controller
    {
        // GET: UserMessage
        /// <summary>
        /// Indexes the specified message content.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="backAction">The back action.</param>
        /// <param name="backController">The back controller.</param>
        /// <returns></returns>
        public ActionResult Index(string messageContent,string backAction, string backController)
        {
            
            //take the back action and controller 
            //and if null the system will redirect to home page
            var BackAction = string.IsNullOrEmpty(backAction)?"Index" :backAction;
            var BackController = string.IsNullOrEmpty(backController) ? "Home": backController;
            ViewBag.message = messageContent;
            ViewBag.backAction = BackAction;
            ViewBag.backController = BackController;
            return View();
        }
     
    }
}