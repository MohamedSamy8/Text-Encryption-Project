using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Encryption_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsInputTextBoxEmpty()
        {
            return string.IsNullOrEmpty(txtInput.Text);
        }
        private bool IsOutputTextBoxEmpty()
        {
            return string.IsNullOrEmpty(txtOutput.Text);
        }

        private bool IsTextBoxesEmpty()
        {
            return (IsInputTextBoxEmpty() || IsOutputTextBoxEmpty());
        }
        private void ResetTextBoxes()
        {
            txtInput.Clear();
            txtOutput.Clear();
        }
        private void ResetLabels()
        {
            lblLength.Text = "Length : ";
            lblOutput.Text = "Output";
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetLabels();
            ResetTextBoxes();
        }

        private string EncryptText()
        {
            string EncryptedText = "";

            for (int i = 0;i <txtInput.TextLength;i++)
            {
                EncryptedText += Convert.ToChar(txtInput.Text[i ]+ Convert.ToInt32(numericUpDown1.Value));
            }

            return EncryptedText;
        }

        private string DecryptText()
        {
            string DecryptedText = "";

            for (int i = 0; i < txtInput.TextLength; i++)
            {
                DecryptedText += Convert.ToChar(txtInput.Text[i] - Convert.ToInt32(numericUpDown1.Value));
            }

            return DecryptedText;
        }

        private void GetLength()
        {
            lblLength.Text = "Length : " + txtInput.Text.Length;
        }
        private void Encrypt()
        {
            lblOutput.Text = "Encrypted \nOutput";
            txtOutput.Text = EncryptText();
        }
        private void Decrypt()
        {
            lblOutput.Text = "Decrypted \nOutput";
            txtOutput.Text = DecryptText();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if(!IsInputTextBoxEmpty())
            {
                Encrypt();

                GetLength();
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!IsInputTextBoxEmpty())
            {
                Decrypt();

                GetLength();
            }

        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (!IsOutputTextBoxEmpty())
            {
                Clipboard.SetText(txtOutput.Text);
            }
        }

        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            if(!IsTextBoxesEmpty())
            {
                txtHistroy.Text += " [ " + DateTime.Now.ToString() + " ] ,";
                txtHistroy.Text += " Input : " + txtInput.Text + " , ";
                txtHistroy.Text += lblOutput.Text + " : " + txtOutput.Text + " ,";
                txtHistroy.Text += " Text " + lblLength.Text + Environment.NewLine;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            txtHistroy.Clear();
        }
    }
}
