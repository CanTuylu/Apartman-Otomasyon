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

namespace MyApartment
{
    public partial class MainForm : Form
    {
        IncomeAccess incomeAccess = new IncomeAccess();
        ExpanseAccess expanseAccess = new ExpanseAccess();
        ApartmentAccess apartmentAccess = new ApartmentAccess();
        PersonAccess personAccess = new PersonAccess();
        HouseAccess houseAccess = new HouseAccess();
        HostAccess hostAccess = new HostAccess();
        Person manager = new Person();
        public MainForm(Person person)
        {
            manager = person;
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (apartmentAccess.GetApartmentInfo() != null)
            {
                Apartment a = apartmentAccess.GetApartmentInfo();
                lblApartmentName.Text = a.ApartmentName + " Apartmanı";
                lblUserName.Text = manager.PersonName + " " + manager.PersonLastName;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNewIncome_Click(object sender, EventArgs e)
        {
            #region UI
            pbIncome.Visible = false;
            btnSaveIncome.Text = "Ekle";
            txtIncomeName.Text = string.Empty;
            txtIncomePrice.Text = string.Empty;
            txtIncomeDescription.Text = string.Empty;
            dtpIncomeDate.Value = DateTime.Now;
            lblIncomeText.Text = "Yeni Kayıt Ekleniyor.";
            #endregion
        }

        private void btnIncomeCancel_Click(object sender, EventArgs e)
        {
            #region UI
            pbIncome.Visible = true;
            #endregion
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            #region UI
            pnlIncome.Visible = true;
            pnlApartment.Visible = false;
            pnlExpanse.Visible = false;
            pnlAccount.Visible = false;
            pnlMain.Visible = false;
            dtpStartDate.Value = DateTime.Now;
            #endregion
        }

        private void btnUpdateIncome_Click(object sender, EventArgs e)
        {
            try
            {
                #region UI
                btnSaveIncome.Text = "Güncelle";
                lblIncomeText.Text = "Kayıt Güncelleniyor.";
                #endregion
                GetIncomeFromListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetIncomeFromListView()
        {
            if (lvIncomes.FocusedItem == null)
                throw new Exception("Bir Gelir Seçmelisiniz.");

            int incomeID = int.Parse(lvIncomes.FocusedItem.Tag.ToString());
            Income income = incomeAccess.GetIncomeByID(incomeID);
            if (income == null)
                throw new Exception("Kayıt veritabanından silinmiş.");

            pbIncome.Visible = false;
            txtIncomeName.Tag = income.IncomeID;
            txtIncomeName.Text = income.IncomeName;
            txtIncomeDescription.Text = income.IncomeDescription;
            txtIncomePrice.Text = income.IncomePrice.ToString();
            dtpIncomeDate.Value = (DateTime)income.IncomeDate;
        }

        private void btnRemoveIncome_Click(object sender, EventArgs e)
        {
            try
            {
                #region UI
                btnSaveIncome.Text = "Sil";
                lblIncomeText.Text = "Kayıt Siliniyor.";
                #endregion
                GetIncomeFromListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFilterIncomes_Click(object sender, EventArgs e)
        {
            List<Income> incomeList;
            lvIncomes.Items.Clear();
            try
            {
                incomeList = incomeAccess.GetIncomesByDate(dtpStartDate.Value);
                if (incomeList.Count <= 0)
                {
                    throw new Exception("Hiç kayıt bulunamadı.");
                }
                FillLvIncomes(incomeList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillLvIncomes(List<Income> incomeList)
        {
            lvIncomes.Items.Clear();
            foreach (var item in incomeList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = item.IncomeID;
                lvi.Text = item.IncomeName;
                lvi.SubItems.Add(item.IncomeDescription);
                lvi.SubItems.Add(String.Format("{0:C2}", item.IncomePrice));
                lvi.SubItems.Add(item.IncomeDate.Value.ToShortDateString());
                lvIncomes.Items.Add(lvi);
            }
        }

        private void btnSaveIncome_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIncomeName.Text == string.Empty || txtIncomePrice.Text == string.Empty)
                    throw new Exception("Ad ve fiyat değerlerini girmelisiniz.");

                if (dtpIncomeDate.Value > DateTime.Now)
                    throw new Exception("Tarih değeri ileri bir tarih olamaz.");

                if (btnSaveIncome.Text == "Ekle")
                {
                    int result = incomeAccess.NewIncome(new Income()
                    {
                        IncomeName = txtIncomeName.Text,
                        IncomeDescription = txtIncomeDescription.Text,
                        IncomePrice = decimal.Parse(txtIncomePrice.Text),
                        IncomeDate = dtpIncomeDate.Value
                    });

                    if (result > 0)
                    {
                        MessageBox.Show("Ekleme başarılı.");
                        pbIncome.Visible = true;
                        lvIncomes.Items.Clear();
                    }
                    else
                        throw new Exception("Eklerken sorun oluştu.");
                }
                else if (btnSaveIncome.Text == "Güncelle")
                {
                    incomeAccess.UpdateIncome(new Income()
                    {
                        IncomeID = int.Parse(txtIncomeName.Tag.ToString()),
                        IncomeName = txtIncomeName.Text,
                        IncomeDescription = txtIncomeDescription.Text,
                        IncomePrice = decimal.Parse(txtIncomePrice.Text),
                        IncomeDate = dtpIncomeDate.Value
                    });

                    MessageBox.Show("Kayıt Güncellendi.");
                    pbIncome.Visible = true;
                    lvIncomes.Items.Clear();
                    lvIncomes.FocusedItem = null;
                }
                else
                {
                    incomeAccess.RemoveIncome(int.Parse(txtIncomeName.Tag.ToString()));
                    MessageBox.Show("Kayıt Silindi.");
                    pbIncome.Visible = true;
                    lvIncomes.Items.Clear();
                    lvIncomes.FocusedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExpanse_Click(object sender, EventArgs e)
        {
            #region UI
            pnlApartment.Visible = false;
            pnlMain.Visible = false;
            pnlIncome.Visible = false;
            pnlExpanse.Visible = true;
            pnlAccount.Visible = false;
            dtpStartDate.Value = DateTime.Now;
            #endregion
        }

        private void btnFilterExpanses_Click(object sender, EventArgs e)
        {
            List<Expanse> expanseList;
            lvExpanses.Items.Clear();
            try
            {
                expanseList = expanseAccess.GetExpansesByDate(dtpExpanseStartDate.Value);
                if (expanseList.Count <= 0)
                {
                    throw new Exception("Hiç kayıt bulunamadı.");
                }
                FillLvExpanses(expanseList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillLvExpanses(List<Expanse> expanseList)
        {
            lvExpanses.Items.Clear();
            foreach (var item in expanseList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = item.ExpenseID;
                lvi.Text = item.ExpenseName;
                lvi.SubItems.Add(item.ExpanseDescription);
                lvi.SubItems.Add(String.Format("{0:C2}", item.ExpansePrice));
                lvi.SubItems.Add(item.ExpanseDate.Value.ToShortDateString());
                lvExpanses.Items.Add(lvi);
            }
        }

        private void btnNewExpanse_Click(object sender, EventArgs e)
        {
            #region MyRegion
            pbIncome.Visible = false;
            btnSaveExpanse.Text = "Ekle";
            txtExpanseName.Text = string.Empty;
            txtExpansePrice.Text = string.Empty;
            txtExpanseDescription.Text = string.Empty;
            dtpExpanseDate.Value = DateTime.Now;
            lblExpanseText.Text = "Yeni Kayıt Ekleniyor.";
            #endregion
        }

        private void btnUpdateExpanse_Click(object sender, EventArgs e)
        {
            try
            {
                #region UI
                btnSaveExpanse.Text = "Güncelle";
                lblExpanseText.Text = "Kayıt Güncelleniyor.";
                #endregion
                GetExpanseFromListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetExpanseFromListView()
        {
            if (lvExpanses.FocusedItem == null)
                throw new Exception("Bir Gider Seçmelisiniz.");

            int expanseID = int.Parse(lvExpanses.FocusedItem.Tag.ToString());
            Expanse expanse = expanseAccess.GetExpanseByID(expanseID);
            if (expanse == null)
                throw new Exception("Kayıt veritabanından silinmiş.");

            pbExpanse.Visible = false;
            txtExpanseName.Tag = expanse.ExpenseID;
            txtExpanseName.Text = expanse.ExpenseName;
            txtExpanseDescription.Text = expanse.ExpanseDescription;
            txtExpansePrice.Text = expanse.ExpansePrice.ToString();
            dtpExpanseDate.Value = (DateTime)expanse.ExpanseDate;
        }

        private void btnRemoveExpanse_Click(object sender, EventArgs e)
        {
            try
            {
                #region UI
                btnSaveExpanse.Text = "Sil";
                lblExpanseText.Text = "Kayıt Siliniyor.";
                #endregion
                GetExpanseFromListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveExpanse_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtExpanseName.Text == string.Empty || txtExpansePrice.Text == string.Empty)
                    throw new Exception("Ad ve fiyat değerlerini girmelisiniz.");

                if (dtpExpanseDate.Value > DateTime.Now)
                    throw new Exception("Tarih değeri ileri bir tarih olamaz.");

                if (btnSaveExpanse.Text == "Ekle")
                {
                    int result = expanseAccess.NewExpanse(new Expanse()
                    {
                        ExpenseName = txtExpanseName.Text,
                        ExpanseDescription = txtExpanseDescription.Text,
                        ExpansePrice = decimal.Parse(txtExpansePrice.Text),
                        ExpanseDate = dtpExpanseDate.Value
                    });

                    if (result > 0)
                    {
                        MessageBox.Show("Ekleme başarılı.");
                        pbExpanse.Visible = true;
                        lvExpanses.Items.Clear();
                    }
                    else
                        throw new Exception("Eklerken sorun oluştu.");
                }
                else if (btnSaveExpanse.Text == "Güncelle")
                {
                    expanseAccess.UpdateExpanse(new Expanse()
                    {
                        ExpenseID = int.Parse(txtExpanseName.Tag.ToString()),
                        ExpenseName = txtExpanseName.Text,
                        ExpanseDescription = txtExpanseDescription.Text,
                        ExpansePrice = decimal.Parse(txtExpansePrice.Text),
                        ExpanseDate = dtpExpanseDate.Value
                    });

                    MessageBox.Show("Kayıt Güncellendi.");
                    pbExpanse.Visible = true;
                    lvExpanses.Items.Clear();
                    lvExpanses.FocusedItem = null;
                }
                else
                {
                    expanseAccess.RemoveExpanse(int.Parse(txtExpanseName.Tag.ToString()));
                    MessageBox.Show("Kayıt Silindi.");
                    pbIncome.Visible = true;
                    lvExpanses.Items.Clear();
                    lvExpanses.FocusedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelExpanse_Click(object sender, EventArgs e)
        {
            #region UI
            pbExpanse.Visible = true;
            #endregion
        }

        private void btnApartment_Click(object sender, EventArgs e)
        {
            #region UI
            pnlApartment.Visible = true;
            pnlExpanse.Visible = false;
            pnlIncome.Visible = false;
            pnlAccount.Visible = false;
            pnlMain.Visible = false;
            #endregion

            btnApartmentDetails_Click(this, null);
        }

        private void btnSaveApartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (apartmentAccess.GetApartmentInfo() != null)
                {
                    apartmentAccess.UpdateApartment(new Apartment()
                    {
                        ApartmentID = int.Parse(txtApartmentNo.Tag.ToString()),
                        ApartmentName = txtApartmentName.Text,
                        ApartmentNo = txtApartmentNo.Text,
                        ApartmentAddress = txtApartmentAddress.Text
                    });
                    MessageBox.Show("Apartman Bilgileri Güncellendi.");
                }
                else
                {
                    apartmentAccess.NewApartment(new Apartment()
                    {
                        ApartmentName = txtApartmentName.Text,
                        ApartmentNo = txtApartmentNo.Text,
                        ApartmentAddress = txtApartmentAddress.Text
                    });

                    MessageBox.Show("Yeni Apartman Eklendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPersonName.Text == string.Empty || txtPersonLastName.Text == string.Empty || txtPersonTC.Text == string.Empty)
                    throw new Exception("Tüm alanları doldurmalısınız.");

                manager.PersonName = txtPersonName.Text;
                manager.PersonLastName = txtPersonLastName.Text;
                manager.PersonTC = txtPersonTC.Text;
                personAccess.UpdatePerson(manager);
                MessageBox.Show("Güncelleme Başarılı");
                btnAccount_Click(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            try
            {
                #region UI
                txtNewPassword.Text = string.Empty;
                txtNewPasswordRepeat.Text = string.Empty;
                txtOldPassword.Text = string.Empty;
                pnlAccount.Visible = true;
                pnlApartment.Visible = false;
                pnlExpanse.Visible = false;
                pnlIncome.Visible = false;
                pnlMain.Visible = false;
                #endregion

                txtPersonName.Tag = manager.PersonID.ToString();
                txtPersonName.Text = manager.PersonName;
                txtPersonLastName.Text = manager.PersonLastName;
                txtPersonTC.Text = manager.PersonTC;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.PersonPassword != txtOldPassword.Text)
                    throw new Exception("Eski şifreniz hatalı.");

                if (txtNewPassword.Text != txtNewPasswordRepeat.Text)
                    throw new Exception("Yeni Şifreler Eşleşmiyor");

                manager.PersonPassword = txtNewPassword.Text;
                personAccess.UpdatePerson(manager);
                MessageBox.Show("Şifre Güncellendi.");

                txtNewPassword.Text = string.Empty;
                txtNewPasswordRepeat.Text = string.Empty;
                txtOldPassword.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApartmentDetails_Click(object sender, EventArgs e)
        {
            pnlApartmentDetails.Visible = true;
            pnlHouses.Visible = false;

            if (apartmentAccess.GetApartmentInfo() != null)
            {
                Apartment a = apartmentAccess.GetApartmentInfo();
                txtApartmentNo.Tag = a.ApartmentID.ToString();
                txtApartmentNo.Text = a.ApartmentNo;
                txtApartmentName.Text = a.ApartmentName;
                txtApartmentAddress.Text = a.ApartmentAddress;
            }
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            try
            {
                pnlApartmentDetails.Visible = false;
                pnlHouses.Visible = true;

                FillHousesToFlpHouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillHousesToFlpHouses()
        {
            flpHouses.Controls.Clear();
            List<House> houseList = houseAccess.GetHouses();
            foreach (House h in houseList)
            {
                Button btnHouse = new Button();
                btnHouse.Text = h.HouseNo;
                btnHouse.Tag = h.HouseID;
                btnHouse.Height = 51;
                btnHouse.Width = 77;
                btnHouse.Click += BtnHouse_Click;

                flpHouses.Controls.Add(btnHouse);
            }
        }

        private void BtnHouse_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                int houseID = int.Parse(btn.Tag.ToString());

                House house = houseAccess.GetHouseByID(houseID);
                HouseHost houseHost = hostAccess.GetHostByID((int)house.HouseHostID);

                txtHouseNo.Tag = house.HouseID.ToString();
                txtHouseNo.Text = house.HouseNo;
                txtHouseFloor.Text = house.HouseFloor;

                txtHostName.Tag = houseHost.HostID.ToString();
                txtHostName.Text = houseHost.HostName;
                txtHostLastName.Text = houseHost.HostLastName;
                txtHostPhone.Text = houseHost.HostPhone;
                txtHostTC.Text = houseHost.HostTC;
                pbHouse.Visible = false;
                btnSaveHouse.Text = "Güncelle";
                lblHouseText.Text = "Daire Bilgileri Güncelleniyor.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewHouse_Click(object sender, EventArgs e)
        {
            #region UI
            txtHouseNo.Text = string.Empty;
            txtHouseFloor.Text = string.Empty;
            txtHostName.Text = string.Empty;
            txtHostLastName.Text = string.Empty;
            txtHostPhone.Text = string.Empty;
            txtHostTC.Text = string.Empty;
            btnSaveHouse.Text = "Ekle";
            lblHouseText.Text = "Yeni Daire Ekleniyor.";
            pbHouse.Visible = false;
            #endregion
        }
        
        private void btnCancelHouse_Click(object sender, EventArgs e)
        {
            #region UI
            pbHouse.Visible = true;
            #endregion
        }

        private void btnSaveHouse_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHostName.Text == string.Empty || txtHostLastName.Text == string.Empty || txtHostPhone.Text == string.Empty || txtHostTC.Text == string.Empty || txtHouseNo.Text == string.Empty || txtHouseFloor.Text == string.Empty)
                {
                    throw new Exception("Tüm alanları doldurmalısınız.");
                }

                if (btnSaveHouse.Text == "Ekle")  // Yeni Daire Ekleme
                {
                    HouseHost houseHost = new HouseHost()
                    {
                        HostName = txtHostName.Text,
                        HostLastName = txtHostLastName.Text,
                        HostPhone = txtHostPhone.Text,
                        HostTC = txtHostTC.Text,
                        HostIsRemoved = false
                    };
                    hostAccess.NewHost(houseHost);

                    houseAccess.NewHouse(new House()
                    {
                        HouseNo = txtHouseNo.Text,
                        HouseFloor = txtHouseFloor.Text,
                        HouseHostID = houseHost.HostID
                    });

                    MessageBox.Show("Yeni Daire Eklendi.");
                    pbHouse.Visible = true;
                    FillHousesToFlpHouses();
                }
                else // Daire Bilgilerinin Güncellenmesi
                {
                    hostAccess.UpdateHost(new HouseHost()
                    {
                        HostID = int.Parse(txtHouseNo.Tag.ToString()),
                        HostName = txtHostName.Text,
                        HostLastName = txtHostLastName.Text,
                        HostPhone = txtHostPhone.Text,
                        HostTC = txtHostTC.Text,
                        HostIsRemoved = false
                    });

                    houseAccess.UpdateHouse(new House()
                    {
                        HouseID = int.Parse(txtHouseNo.Tag.ToString()),
                        HouseNo = txtHouseNo.Text,
                        HouseFloor = txtHouseFloor.Text,
                        HouseHostID = int.Parse(txtHouseNo.Tag.ToString())
                    });

                    MessageBox.Show("Daire Bilgileri GÜncellendi.");
                    pbHouse.Visible = true;
                    FillHousesToFlpHouses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        /* Ana ekrandaki saat ve tarih değerlerinin güncellenmesi */
        private void timerSaat_Tick(object sender, EventArgs e)
        {
            string saat = DateTime.Now.ToLongTimeString();

            lblSaat.Text = saat;
            lblDateTime.Text = DateTime.Now.ToLongDateString();
        }

        private void lblMainPanel_Click(object sender, EventArgs e)
        {
            #region UI
            pnlAccount.Visible = false;
            pnlApartment.Visible = false;
            pnlExpanse.Visible = false;
            pnlIncome.Visible = false;
            pnlMain.Visible = true;
            #endregion
        }

    }
}
