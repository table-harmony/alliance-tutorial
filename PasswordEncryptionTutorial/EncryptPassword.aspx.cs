using PasswordEncryptionTutorial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordEncryptionTutorial {
    public partial class EncryptPassword : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Encrypt_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PasswordInput.Text)) {
                StatusLabel.Text = "Please input a password";
                return;
            }

            try {
                string encryption = SHA256Encryption.Encrypt(PasswordInput.Text);

                StatusLabel.Text = "Password encrypted successfully! " + encryption;
            } catch (Exception ex) {
                StatusLabel.Text = "Encryption failed: " + ex.Message;
            }
        }
    }
}