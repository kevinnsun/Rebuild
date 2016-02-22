/*Rebuild
 * This amazing, high-tech, awesome program was built by Ubisoft's very own Kevin Sunster, Cindy "Hair-Cut" Yo, and Maximus Zhang.
 * 
 *Kevin Sun, Max Zhang, Cindy Hou
 *June 12th 2013
 *Mr. Hsiung
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rebuild
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // When btnNewFile is clicked
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            //check if the file name is valide or not
            if (txtNewFile.Text != "")
            {
                //run kevin form
                KevinForm Kevin = new KevinForm(txtNewFile.Text);
                Kevin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You need a name");
            }
        }

        //When the load button is clicked
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            //check if the load file is valid or not 
            if (txtLoadFile.Text != "")
            {
                int numCols;
                int numRows;

                //check if the file exists
                if (File.Exists(txtLoadFile.Text) == true)
                {
                    //read the file 
                    using (StreamReader sr = new StreamReader(txtLoadFile.Text))
                    {
                        int.TryParse(sr.ReadLine(), out numCols);
                        int.TryParse(sr.ReadLine(), out numRows);
                    }
                    //start kevin form
                    KevinForm kevin = new KevinForm(txtLoadFile.Text, numCols, numRows);
                    kevin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("File does not exist");
                }
            }
            else
            {
                MessageBox.Show("Invalid File Name");
            }
        }
    }
}
