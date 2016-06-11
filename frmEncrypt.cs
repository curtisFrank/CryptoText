//*************************************************************************
// Name: frmEncrypt.cs
// Programmer: Curtis N Frank
// Date: 4/20/2016
// Purpose: This form allows user to enter text, then encrypt and save
//          as a text file.
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
using System.Diagnostics;

namespace CryptoText
{
    public partial class frmEncrypt : Form
    {
        private string fileName = "";

        // constructor
        public frmEncrypt()
        {
            InitializeComponent();
        }

        // encrypt button click event handler
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // get user input
            string input = txtMessage.Text;

            // instantiate new list
            List<char>output = new List<char>();

            // local variables
            int temp;

            // loop to traverse string
            foreach (char x in input)
            {
                // add characters to list
                output.Add(x);
            }

            // loop
            for(int i = 0; i < output.Count; i++)
            {
                // convert list item to integer and
                // alter (+10) then convert back to
                // character and overwrite original
                temp = Convert.ToInt32(output[i]);
                temp += 10;
                output[i] = Convert.ToChar(temp);
            }

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;

                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    // open a sequential access file for output
                    StreamWriter outFile = new StreamWriter(myStream);

                    // loop to traverse list
                    foreach (char z in output)
                    {
                        // write character to file
                        outFile.Write(z);

                        // write space to file
                        outFile.Write(" ");
                    }

                    // close the file
                    outFile.Close();

                    // confirmation message
                    MessageBox.Show("Message encrypted.",
                                    "CryptoText",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    myStream.Close();
                }
            }


            

            // open the encrypted text file in Notepad
            Process.Start("notepad.exe", fileName);
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
            // reset textbox text and focus
            txtMessage.Text = "";
            txtMessage.Focus();
        }

        // form loading event handler
        private void frmEncrypt_Load(object sender, EventArgs e)
        {    
            // reset textbox text and focus
            //txtFilename.Text = "filename.txt";
            //txtFilename.Focus();
            //txtFilename.SelectAll();
        }
    }
}
