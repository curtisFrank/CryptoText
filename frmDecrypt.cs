//*************************************************************************
// Name: frmDecrypt.cs
// Programmer: Curtis N Frank
// Date: 4/20/2016
// Purpose: This form allows users to open and decrypt text files and
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
using System.IO;

namespace CryptoText
{
    public partial class frmDecrypt : Form
    {
        private string fileName = "";

        // constructor
        public frmDecrypt()
        {
            InitializeComponent();
        }

        // exit button click event handler
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        // clear button click event handler
        private void btnClear_Click(object sender, EventArgs e)
        {
            // reset textbox and focus            
            txtMessage.Text = "";
            txtMessage.Focus();     
        }

        // decrypt button click event handler
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // instantiate new integer list
            List<int> input = new List<int>();

            // local variables
            int x;
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

                try
                {
                    if ((openFileDialog1.OpenFile()) != null)
                    {
                       
                        // Insert code to read the stream here.
                            
                        // open sequential access file for input
                        StreamReader inFile = new StreamReader(openFileDialog1.FileName);

                        // loop until end of file...
                        while (!inFile.EndOfStream)
                        {
                            // read ASCII value
                            x = (inFile.Read());

                            // skip the spaces...
                            if (Convert.ToChar(x) != ' ')
                            {
                                // add integer to list
                                input.Add(x);
                            }
                        }

                        // close the file
                        inFile.Close();

                        // loop to traverse list...
                        for (int i = 0; i < input.Count(); i++)
                        {
                            // alter each item
                            input[i] -= 10;

                            // convert items to characters and
                            // output to textbox
                            txtMessage.Text += Convert.ToChar(input[i]);
                        }                                                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }            
        }

        // helper method
        private void showMessage(string input)
        {
            // display string argument in message box
            MessageBox.Show(
                    input,
                    "CryptoText",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            // reset focus
            
            //txtFiltxtFilenameename.SelectAll();
        }

        // form loading event handler
        private void frmDecrypt_Load(object sender, EventArgs e)
        {
            // reset textbox and focus
            //txtFilename.Text = "filename.txt";
            //txtFilename.Focus();
            //txtFilename.SelectAll();
        }
    }
}
