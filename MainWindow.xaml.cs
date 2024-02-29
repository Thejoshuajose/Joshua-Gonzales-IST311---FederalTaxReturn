using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Joshua_Gonzales___IST311___FederalTaxReturn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml (Federal Tax Return System For IST 311)
    /// </summary>
    /// 
    ///@author Joshua Gonzales 
    ///
    public partial class MainWindow : Window
    {
        String socialSecurity = "";
        String firstName = "";
        String lastName = "";
        int dependant = -1;
        String maritalStatus = "";
        double grossAnnualIncome = 0;
        double charitableDeduction = 0;
        double mortgageInterest = 0;
        double totalDeduction = 0;

        public MainWindow()
        {
            InitializeComponent();
            txtSocialSecurity.Focus();
            txtLastName.Text = "Last Name";
            txtFirstName.Text = "First Name";
            btnCalculate.IsEnabled = false;
            Refresh_Calc_Btn();
        }

        
        private void txtSocialSecurity_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtSocialSecurity.Text == "999-99-9999")
            {
                txtSocialSecurity.Clear();
                
            }
        }


        private void txtSocialSecurity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSocialSecurity.Text != "999-99-9999")
            {
                socialSecurity = txtSocialSecurity.Text;
            }
            if (txtSocialSecurity.Text == "")
            {
                txtSocialSecurity.Text = "999-99-9999";
            }
            Refresh_Calc_Btn();
        }

        private void txtSocialSecurity_TextChanged(object sender, TextChangedEventArgs e)
       {
            ssnCheck();

            if(txtSocialSecurity.Text == "" || txtSocialSecurity.Text.Length < 11 || txtSocialSecurity.Text == "999-99-9999")
            {
                txtSocialSecurity.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (txtSocialSecurity.Text.Length == 11 && txtSocialSecurity.Text != "999-99-9999")
            {
                txtSocialSecurity.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }
            
        }
        private void radSingle_Checked(object sender, RoutedEventArgs e)
        {
            maritalStatus = "Single";
            Refresh_Calc_Btn();
        }

        private void radMarried_Checked(object sender, RoutedEventArgs e)
        {
            maritalStatus = "Married";
            Refresh_Calc_Btn();
        }


        private void radSeperated_Checked(object sender, RoutedEventArgs e)
        {
            maritalStatus = "Seperated";
            Refresh_Calc_Btn();
        }

        private void radHOH_Checked(object sender, RoutedEventArgs e)
        {
            maritalStatus = "HOH";
            Refresh_Calc_Btn();
        }

        private void txtLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLastName.Text == "Last Name")
            {
                txtLastName.Clear();
            }
        }

        private void txtFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "First Name")
            {
                txtFirstName.Clear();
            }
        }
        private void txtCharitableDeduction_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCharitableDeduction.Text == "Charitable Deduction")
            {
                txtCharitableDeduction.Clear();
            }
            if (txtCharitableDeduction.Text.StartsWith("$"))
            {
                txtCharitableDeduction.Text = txtCharitableDeduction.Text.Replace("$", "");

            }
        }

        private void txtGrossAnnualInclome_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtGrossAnnualInclome.Text == "Gross Annual Income")
            {
                txtGrossAnnualInclome.Clear();
            }
            if (txtGrossAnnualInclome.Text.StartsWith("$"))
            {
                txtGrossAnnualInclome.Text = txtGrossAnnualInclome.Text.Replace("$","");

            }
        }
        private void txtMortgageInterest_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtMortgageInterest.Text == "Mortgage Interest")
            {
                txtMortgageInterest.Clear();
            }
            if (txtMortgageInterest.Text.StartsWith("$"))
            {
                txtMortgageInterest.Text = txtMortgageInterest.Text.Replace("$", "");
            }

        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "First Name")
            {
                firstName = txtFirstName.Text;
                txtFirstName.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = "First Name";
                txtFirstName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            Refresh_Calc_Btn();


        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLastName.Text != "Last Name")
            {
               lastName = txtLastName.Text;
               txtLastName.BorderBrush =  new SolidColorBrush(Colors.LightGray);
            }
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "Last Name";
                txtLastName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            Refresh_Calc_Btn();
        }

        private void txtGrossAnnualInclome_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtGrossAnnualInclome.Text == "")
            {
                txtGrossAnnualInclome.Text = "Gross Annual Income";
                txtGrossAnnualInclome.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (txtGrossAnnualInclome.Text != "Gross Annual Income")
            {
                if (!txtGrossAnnualInclome.Text.StartsWith("$"))
                {
                    grossAnnualIncome = double.Parse(txtGrossAnnualInclome.Text);
                    txtGrossAnnualInclome.Text = moneyFormat(grossAnnualIncome);
                    txtGrossAnnualInclome.BorderBrush = new SolidColorBrush(Colors.LightGray);
                }
                
            }
            Refresh_Calc_Btn();
        }
        private void txtCharitableDeduction_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCharitableDeduction.Text == "")
            {
                txtCharitableDeduction.Text = "Charitable Deduction";
                txtCharitableDeduction.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (txtCharitableDeduction.Text != "Charitable Deduction" )
            {
                if (!txtCharitableDeduction.Text.StartsWith("$"))
                {
                    charitableDeduction = double.Parse(txtCharitableDeduction.Text);
                    txtCharitableDeduction.Text = moneyFormat(charitableDeduction);
                    txtCharitableDeduction.BorderBrush = new SolidColorBrush(Colors.LightGray);
                }
            }
            Refresh_Calc_Btn();
        }
        private void txtMortgageInterest_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtMortgageInterest.Text == "")
            {
                txtMortgageInterest.Text = "Mortgage Interest";
                txtMortgageInterest.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (txtMortgageInterest.Text != "Mortgage Interest")
            {
                if (!txtMortgageInterest.Text.StartsWith("$"))
                {
                    mortgageInterest = double.Parse(txtMortgageInterest.Text);
                    txtMortgageInterest.Text = moneyFormat(mortgageInterest);
                    txtMortgageInterest.BorderBrush = new SolidColorBrush(Colors.LightGray);
                }
            }
            Refresh_Calc_Btn();
        }
        private void radZero_Checked(object sender, RoutedEventArgs e)
        {
            dependant = 0;
            Refresh_Calc_Btn();
        }
        private void radOneDep_Checked(object sender, RoutedEventArgs e)
        {
            dependant = 1;
            Refresh_Calc_Btn();
        }

        private void radTwoDep_Checked(object sender, RoutedEventArgs e)
        {
            dependant = 2;
            Refresh_Calc_Btn();
        }
        private void radThreeDep_Checked(object sender, RoutedEventArgs e)
        {
            dependant = 3;
            Refresh_Calc_Btn();
        }
        private void radFourDep_Checked(object sender, RoutedEventArgs e)
        {
            dependant = 4;
            Refresh_Calc_Btn();
        }

        private void radFiveDep_Checked(object sender, RoutedEventArgs e)
        {
            dependant = 5;
            Refresh_Calc_Btn();
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh_Calc_Btn();
        }
        private void txtTotalOwedOrRef_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(totalDeduction > 0)
            {
                txtTotalOwedOrRef.BorderBrush = new SolidColorBrush(Colors.Green);

            }
            if (totalDeduction < 0)
            {
                txtTotalOwedOrRef.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }
        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh_Calc_Btn();
        }

        private void txtGrossAnualInclome_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh_Calc_Btn();
        }
        private void txtCharitableDeduction_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh_Calc_Btn();
        }
        private void txtMortgageInterest_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh_Calc_Btn();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = "First Name";
            txtLastName.Text = "Last Name";
            txtFullName.Text = "Full Name";
            txtSocialSecurity.Text = "999-99-9999";
            txtSocialSecurity.BorderBrush = new SolidColorBrush(Colors.LightGray);
            txtTotalOwedOrRef.Text = "Total Owed or To Be Refunded";
            txtMortgageInterest.Text = "Mortgage Interest";
            txtCharitableDeduction.Text = "Charitable Deduction";
            txtGrossAnnualInclome.Text = "Gross Anual Income";
            radZeroDep.IsChecked = false;
            radOneDep.IsChecked = false;
            radMarried.IsChecked = false;
            radTwoDep.IsChecked = false;
            radHOH.IsChecked = false;
            radFourDep.IsChecked = false;
            radFiveDep.IsChecked = false;
            radThreeDep.IsChecked = false;
            radSingle.IsChecked = false;
            radSeperated.IsChecked = false;
            btnCalculate.IsEnabled = false;
            totalDeduction = 0;
            txtTotalOwedOrRef.BorderBrush = new SolidColorBrush(Colors.LightGray);
            charitableDeduction = 0;
            grossAnnualIncome = 0;
            mortgageInterest = 0;
            dependant = -1;
            MessageBox.Show("Items Have Been Cleared");
        }

       
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you Sure?", "Do you want to Exit?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double DepDeduction = dependant * 5000;
            double filStat = 0;
            if(maritalStatus == "Single") 
            {
                filStat = 0.25 ;
            }
            else if (maritalStatus == "Married")
            {
                filStat = 0.18;
            }
            else if (maritalStatus == "Seperated")
            {
                filStat = 0.18;
            }
            else if (maritalStatus == "HOH")
            {
                filStat = 0.20;
            }
            

            txtFullName.Text = txtLastName.Text + ", " + txtFirstName.Text;

            double FilStatDedction = grossAnnualIncome * filStat;
            totalDeduction = FilStatDedction + DepDeduction + charitableDeduction + mortgageInterest;
            txtTotalOwedOrRef.Text = moneyFormat(totalDeduction);
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            Refresh_Calc_Btn();
        }

        private void Refresh_Calc_Btn() { 
            if(txtFirstName.Text == "First Name" || txtFirstName.Text == "")
            {
                
            }
            else if (txtLastName.Text == "Last Name" || txtLastName.Text == "")
            {

            }
            else if (txtGrossAnnualInclome.Text == "Gross Anual Income" || txtGrossAnnualInclome.Text == "")
            {

            }
            else if (txtMortgageInterest.Text == "Mortgage Interest" || txtMortgageInterest.Text == "")
            {

            }
            else if (txtSocialSecurity.Text == "999-99-9999" || txtSocialSecurity.Text == "")
            {

            }
            else if (txtCharitableDeduction.Text == "Charitable Deduction" || txtCharitableDeduction.Text == "")
            {

            }
            else if (dependant.Equals(-1))
            {

            }
            else if (maritalStatus == "")
            {

            }
            else { btnCalculate.IsEnabled = true;}
        }

        private void ssnCheck()
        {
            if (txtSocialSecurity.Text != null)
            {
                socialSecurity = txtSocialSecurity.Text;

                if (txtSocialSecurity.Text.Length == 9)
                {
                    if (txtSocialSecurity.Text.Contains("-") == false)
                    {
                        string formattedSSN = string.Join("-", socialSecurity.Substring(0, 3), socialSecurity.Substring(3, 2), socialSecurity.Substring(5, 4));
                        txtSocialSecurity.Text = formattedSSN;
                        txtSocialSecurity.SelectionStart = txtSocialSecurity.Text.Length;
                        Refresh_Calc_Btn();
                    }
                }


                if (socialSecurity.Contains("-") == true && txtSocialSecurity.Text.Length < 11)
                {
                    String one = txtSocialSecurity.Text.Replace("-", "");
                    String two = txtSocialSecurity.Text.Replace("-", "");
                    txtSocialSecurity.Text = two;
                    txtSocialSecurity.SelectionStart = txtSocialSecurity.Text.Length;


                }
            }
        }

        private static string moneyFormat(double money)
        {
            string newCurrency = "";
            newCurrency = string.Format(new CultureInfo("en-US"), "{0:C}", money);
            return newCurrency;
        }

        

        
    }
}