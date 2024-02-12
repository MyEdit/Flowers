using System;
using System.Windows.Forms;

namespace Flowers
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void reloadCaptcha()
        {
            captcha1.CreateCaptcha = false;
            captcha1.CreateCaptcha = true;
        }

        private void captcha1_Click(object sender, EventArgs e)
        {
            reloadCaptcha();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (!textBoxCaptcha.Text.ToLower().Equals(captcha1.CaptchaText.ToLower()))
            {
                MessageBox.Show("Каптча введена неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reloadCaptcha();
                return;
            }

            int userID = DataBaseWorker.ExecuteQueryOnlyOneInt("SELECT UserID FROM Users WHERE UserLogin = '" + textBoxLogin.Text + "' AND UserPassword = '" + textBoxPass.Text + "'");

            if (userID == -1)
            {
                MessageBox.Show("Логин или пароль неверный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm MainForm = new MainForm(userID);
            MainForm.Show();
            Hide();
        }
    }
}
