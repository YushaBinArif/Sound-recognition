using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication13
{
   
    public partial class VPlayer : MetroFramework.Forms.MetroForm
    {
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        SpeechSynthesizer sys = new SpeechSynthesizer();
        PromptBuilder prmpb = new PromptBuilder();
        public VPlayer()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Choices slist = new Choices();
            //slist.Add(new string[] {"call ami" ,"recite surah al fatiha", "surah al fatiha", "parho surah al fatiha", "parho", "search", "jarvis", "google", "open", "open facebook", "open youtube", "open twitter", "open google" });
            //Grammar gr = new Grammar(new GrammarBuilder(slist));
            //try
            //{
            //    sre.RequestRecognizerUpdate();
            //    sre.LoadGrammar(gr);
            //    sre.SpeechRecognized += sre_SpeechRecognized; //new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            //    sre.SetInputToDefaultAudioDevice();
            //    sre.RecognizeAsync(RecognizeMode.Multiple);

            //}
            //catch
            //{
            //    return;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choices slist = new Choices();
             slist.Add(new string[] {"call","call yusha","call ami","parho surah al fatiha","parho","stop","recite surah al fatiha", "surah al fatiha", "search facebook", "search mehran", "search", "jarvis", "google", "open", "open facebook", "open youtube", "open twitter", "open google" });
             Grammar gr = new Grammar(new GrammarBuilder(slist));
             try
             {
                 sre.RequestRecognizerUpdate();
                 sre.LoadGrammar(gr);
                 sre.SpeechRecognized += sre_SpeechRecognized; //new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
                 sre.SetInputToDefaultAudioDevice();
                 sre.RecognizeAsync(RecognizeMode.Multiple);
                // MessageBox.Show("done");

             }
             catch
             {
                 return;
             }
             
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("done");
            textBox1.Text += e.Result.Text;
            if (e.Result.Text == "open google")
            {
                Process.Start("www.google.com");
                sys.Dispose();
            }
            else if (e.Result.Text == "open facebook")
            {
                Process.Start("www.facebook.com");
            }

            else if (e.Result.Text == "open twitter")
            {
                Process.Start("www.twitter.com");
            }
            else if (e.Result.Text == "open youtube")
            {
                Process.Start("www.youtube.com");
            }
            if ((e.Result.Text == "surah al fatiha") || (e.Result.Text == "recite surah al fatiha") || (e.Result.Text == "parho surah al fatiha"))
            {
                wmplayer.Visible = true;
                wmplayer.URL = @"C:\Users\Yousha Arif\Desktop\001.mp3";
                wmplayer.settings.volume = 100;
            }
            else if ((e.Result.Text == "call yusha")||(e.Result.Text == "call"))
            {
                prmpb.ClearContent();
                prmpb.AppendText("ok");
                sys.Speak(prmpb);
                Process.Start("Skype"," /callto:youshaarif");
                
            }
            //else if (e.Result.Text == "open")
            //{
            //    textBox1.Text = e.Result.Text[0].ToString();
            //    // Process.Start("www.google.com.pk/#q="+e.Result.Text[1]);
            //}

            //else
            //{
            //    prmpb.ClearContent();
            //    prmpb.AppendText("sorry try again");
            //    sys.Speak(prmpb);
            //}
            ////textBox1.Text = e.Result.Text;  
  
  
            //throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prmpb.ClearContent();
            prmpb.AppendText(textBox1.Text);
            sys.Speak(prmpb);
        }
    }
}
