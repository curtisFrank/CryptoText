//*************************************************************************
// Name: frmMain.cs (frmCryptoText)
// Programmer: Curtis N Frank
// Date: 4/20/2016
// Purpose: This application encrypts text messages and saves them in
//          text file format, as well as decrypts the text files to
//          display the text in the user interface.
//*************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoText
{
    public partial class frmCryptoText : Form
    {
        // constructor
        public frmCryptoText()
        {
            InitializeComponent();
        }

        // encrypt button click event handler
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // open the Encrypt Message form
            frmEncrypt f1 = new frmEncrypt();
            f1.Show();            
        }

        // exit button click event handler
        private void btnExit_Click(object sender, EventArgs e)
        {
            // exit main program
            this.Close();
        }

        // decrypt button click event handler
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // open the Decrypt File
            frmDecrypt fD = new frmDecrypt();   
            fD.Show();
        }
    }
}
