using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmControlAsistenciaSpeech : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        private string _speech;
        public frmControlAsistenciaSpeech(string speech)
        {
            _speech = speech;
            InitializeComponent();
        }

        private void frmControlAsistenciaSpeech_Load(object sender, EventArgs e)
        {
            string st = "";
            listBox1.Items.Clear();
            foreach (InstalledVoice v in synth.GetInstalledVoices())
            {
                listBox1.Items.Add(v.VoiceInfo.Name);
            }

            if (listBox1.Items.Count > 0) listBox1.SelectedIndex = 0;

            synth.SetOutputToDefaultAudioDevice();
            textBox2.Text = _speech;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            synth.SpeakAsync(textBox2.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            synth.SelectVoice(listBox1.Text);
        }
    }
}
