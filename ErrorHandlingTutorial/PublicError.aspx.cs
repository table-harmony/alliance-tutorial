using ErrorHandlingTutorial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ErrorHandlingTutorial {
    public partial class PublicError : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ThrowErrorButton_Click(object sender, EventArgs e) {
            throw new PublicException("This is a user-friendly error message that can be safely shown to the public.");
        }
    }
}