using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;


namespace MisesAJourMB
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WebClient _webClient = new WebClient();

            try
            {
                string url_exe = "http://www.memoireboy.fr/memoireboy/memoireboy2013.exe";
                string _path = Application.StartupPath + @"\"+"MemoireBoy2013.exe";

                if (File.Exists(Application.StartupPath + @"\" + "MemoireBoy2013.exe"))
                {
                    File.Delete(Application.StartupPath + @"\" + "MemoireBoy2013.exe");
                }

               
                _webClient.Headers.Add("User-Agent", "Mozilla");
                _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(_webClient_DownloadFileCompleted); 
                _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(_webClient_DownloadProgressChanged);
                _webClient.DownloadFileAsync(new Uri(url_exe),_path);
                this.button1.Text = "téléchargement en cours...";



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void _webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.button1.Text = "téléchargement fini !";

            this.demarrerMB(); _deja = true;

            Application.Exit();
        }


        private void _webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Met à jour la position de la barre de progression à partir 
            // de l'état d'avancement contenu dans l'attribut ProgressPercentage 
            this.progressBar1.Value = e.ProgressPercentage;
        }


        bool _deja = false;
        private void demarrerMB()
        {
            try
            {
                // Instance de la classe Process
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                // Nom du fichier dont l'extension est connue du shell à ouvrir

                proc.StartInfo.FileName = Application.StartupPath + @"\" + "MemoireBoy2013.exe";
                // Démarrage du processus. 
                // Notepad, si il est associé aux fichiers .txt,
                // sera lancé et ouvrira le fichier monfichier.txt

                proc.Start();
                // On libère les ressources dont on a plus besoin.
                proc.Close(); // Attention Close ne met pas fin au processus.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_deja) { this.demarrerMB(); }
        }
    }
}
