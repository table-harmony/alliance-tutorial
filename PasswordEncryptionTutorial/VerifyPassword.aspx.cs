using System;
using PasswordEncryptionTutorial.Utils;

namespace PasswordEncryptionTutorial {
    public partial class VerifyPassword : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void VerifyButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PasswordInput.Text) || string.IsNullOrEmpty(EncryptionInput.Text)) {
                StatusLabel.Text = "Please input a password and an encryption";
                return;
            }

            try {
                bool isMatch = SHA256Encryption.Compare(PasswordInput.Text, EncryptionInput.Text);

                if (isMatch)
                    StatusLabel.Text = "Password matches the encryption!";
                else
                    StatusLabel.Text = "Password does not match the encryption.";

            } catch (Exception ex) {
                StatusLabel.Text = "Verification failed: " + ex.Message;
            }
        }
    }
}
