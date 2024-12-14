using ExampleUsage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExampleUsage {
    public partial class Admin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                BindGrid();
            }
        }

        private void BindGrid() {
            UsersGridView.DataSource = Database.Users;
            UsersGridView.DataBind();
        }
    }
}