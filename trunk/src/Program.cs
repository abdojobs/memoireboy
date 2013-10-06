using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MemoireBoy2013
{
    static class Program
    {


        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MBoyForm mbf_log;
            MBoyMain mbm;

            bool bol = BDGestionAccess2013.OUVRIRconnexionBD("memoireboy2013");
            int o = BDGestionAccess2013.COUNT("users", "select count(*) from users");
            bool lob = BDGestionAccess2013.FERMERconnexionBD("memoireboy2013");

            if (o > 0)
            {
                mbf_log = new MBoyForm();
                Application.Run(mbf_log);
            }
            else
            {
                mbm = new MBoyMain();
                Application.Run(mbm);
            }



            
        }
    }
}
