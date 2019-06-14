using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel;

namespace MyApartment
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        PersonAccess personAccess = new PersonAccess();
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (personAccess.IsAnyPersonRegistered())
            {
                pnlLogin.Visible = true;
                pnlRegister.Visible = false;
            }
            else
            {
                pnlRegister.Visible = true;
                pnlLogin.Visible = false;
            }
        }

        private void btnRegisterPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPersonName.Text == string.Empty || txtPersonLastName.Text == string.Empty || txtPersonPassword.Text == string.Empty || txtPersonPasswordRepeat.Text == string.Empty || txtPersonTC.Text == string.Empty)
                    throw new Exception("Tüm alanları doldurmalısınız.");

                if (txtPersonPassword.Text != txtPersonPasswordRepeat.Text)
                    throw new Exception("Şifreler Eşleşmiyor.");

                int anyPersonRegistered = personAccess.RegisterPerson(new Person()
                {
                    PersonName = txtPersonName.Text,
                    PersonLastName = txtPersonLastName.Text,
                    PersonPassword = txtPersonPassword.Text,
                    PersonTC = txtPersonTC.Text
                });

                if (anyPersonRegistered > 0)
                {
                    MessageBox.Show("Kayıt İşlemi Başarılı.");
                    pnlRegister.Visible = false;
                    pnlLogin.Visible = true;
                }
                else
                    throw new Exception("Kayıt İşlemi Yapılamadı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLoginTC.Text == string.Empty || txtLoginPassword.Text == string.Empty)
                    throw new Exception("Tüm alanları doldurmalısınız.");

                bool isTcTrue = personAccess.IsTcTrue(txtLoginTC.Text);

                if (!isTcTrue)
                    throw new Exception("TC Hatalı.");

                bool isPasswordTrue = personAccess.IsPasswordTrue(new LoginVM()
                {
                    TC = txtLoginTC.Text,
                    Password = txtLoginPassword.Text
                });

                if (!isPasswordTrue)
                    throw new Exception("Şifre Hatalı.");

                Person person = personAccess.GetPersonByTc(txtLoginTC.Text);
                MainForm mainForm = new MainForm(person);
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
