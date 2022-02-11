using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TexttoSpeechApp
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer SAP = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (rtSpeak.Text != "")
            {
                SAP = new SpeechSynthesizer();
                SAP.SpeakAsync(rtSpeak.Text);
            }
            else
            {
                rtSpeak.Text = ("Please enter some text");
                SAP = new SpeechSynthesizer();
                SAP.SpeakAsync(rtSpeak.Text);

                await Task.Delay(2000);
                rtSpeak.Clear();
                rtSpeak.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SAP.State == SynthesizerState.Speaking)
            {
                SAP.Pause();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SAP != null)
            {
                if (SAP.State == SynthesizerState.Paused)
                {
                    SAP.Resume();
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)

        {
            SAP.Dispose();  
            SAP = new SpeechSynthesizer();
            SAP.SpeakAsync("Please confirm if you want to exit");

            await Task.Delay(2000);

            DialogResult iExit;

            iExit = MessageBox.Show("Please confirm if you want to exit", "Text To Speech",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();

                {
                    if (rtSpeak.Text != "")
                    {
                        SAP = new SpeechSynthesizer();
                        SAP.SpeakAsync(rtSpeak.Text);
                    }
                }
            }
        }
    }
}

