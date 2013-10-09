using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoireBoy2013
{
    public class PersonneClass
    {

        // TODO : voir si les méthodes de formatage (tel,...) ne suffiraient pas en getter seulement
        // NOTE : à terme, séparer les méthode de formatage dans une classe spécialisée

        #region Champs et Propriétés

        internal int idPers {get; set; }
        internal string civilite { get; set; }
        internal string prenom { get; set; }
        internal string nom { get; set; }
        internal string dateNaissance { get; set; }

        private string Email;
        internal string e_mail
        {
            get { return Email; }
            set { if (IsValidEmail(value)) { Email = value; } }
        }

        private string _telfixe;
        internal string telfixe {
            get { return FormaterTel(_telfixe); }
            set { _telfixe = FormaterTel(value); } 
        }

        internal string telportable { get; set; }
        internal string fax { get; set; }
        internal string adresse { get; set; }
        internal string cp { get; set; }
        internal string ville { get; set; }
        internal string bp { get; set; }
        internal string adrImage { get; set; }
        internal string note { get; set; }
        internal string adrDocCV { get; set; }
        internal string site { get; set; }
        internal string activite { get; set; }

        public string AffichagePersonne { get { return miseEnFormeAffichage(); } }
        public string AffichageTxt { get { return miseEnFormeAffichagePourTxt(); } }

        #endregion

        #region Constructeurs

        public PersonneClass() { }

        public PersonneClass(int cidPers,
                       string cciv,
                       string cpn,
					   string cnom,
					   string cdatenaiss,
			           string email,
                       string ctelfixe,
                       string ctelmobile,
                       string cfax,
                       string cadr,
                       string ccp,
                       string cville,
                       string cbp,
                       string pathImage,
                       string cnote,
                       string cadrCV,
                       string csite,
                       string cactiv
                    )
		{
			idPers = cidPers;
            civilite = cciv;
            prenom = FormaterPn(cpn);
            nom = FormaterNom(cnom);
			dateNaissance = cdatenaiss;
            e_mail = email;
            telfixe = FormaterTel(ctelfixe);
            telportable = FormaterTel(ctelmobile);
			fax = cfax;
            adresse = cadr;
            cp = ccp;
			ville = FormaterNom(cville);
            bp = cbp;
            adrImage = pathImage;
			note=cnote;
            adrDocCV = cadrCV;
            site = csite;
            activite = cactiv;
		}

        #endregion

        private string miseEnFormeAffichage()
        {
            string format_fix = string.Empty;
            string format_mob = string.Empty;
            // NOTE : civ initialisée avec un caractère espace ?
            string civ = " ";
            string pren = string.Empty;

            if ( !string.IsNullOrEmpty(telfixe))
            { 
                format_fix = string.Format("[{0}] ", telfixe); 
            }
            if (!string.IsNullOrEmpty(telportable)) 
            { 
                format_mob = string.Format(" [{0}] ", telportable); 
            }
            if (!string.IsNullOrEmpty(civilite)) 
            {
                civ = string.Format("  ({0})  ", civilite);
            }
            if (!string.IsNullOrEmpty(prenom)) 
            { 
                pren = " "; 
            }

            return string.Concat(prenom, pren, nom, civ, format_fix, format_mob, e_mail);
        }

        private string miseEnFormeAffichagePourTxt()
        {
            return string.Format("({0}),{1},{2},{3},{4},{5}", civilite, prenom, nom, telfixe, telportable, e_mail);
        }

        public static string FormaterNom(string nom)
        {
            return nom.ToUpper();
        }

        public static string FormaterPn(string pn)
        {
            return pn.ToLower();
        }

        public static string FormaterTel(string telNumber)
        {
            char[] tel = telNumber.ToCharArray();
            char[] chiffre = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string num = string.Empty;

            foreach (char i in tel)
            {
                if (chiffre.Contains(i))
                {
                    string.Concat(num, i);
                }
            }
            //for (int i = 0; i < tel.Length; i++)
            //{
            //    for (int j = 0; j < chiffre.Length; j++)
            //    {
            //        if (tel[i] == chiffre[j])
            //        {
            //            num += tel[i].ToString(); 
            //            break;
            //        }
            //    }
            //}

            if (num.Length == 9) 
            { 
                num = num.Insert(0, "0");
            }

            return (num.Length == 10) ? num : string.Empty;
            //char[] cptChiffres = num.ToCharArray();
            //string NewNum = string.Empty;
            //if (cptChiffres.Length == 10)
            //{
            //    for (int p = 0; p < cptChiffres.Length; p++)
            //    {
            //        // if (p == 2 || p == 4 || p == 6 || p == 8) { NewNum += "."; }
            //        NewNum += cptChiffres[p].ToString();
            //    }
            //}
            //return NewNum;
        }

        public static bool IsValidEmail(string mail)
        {
            return (mail.Contains('@')&&(mail.Contains('.'))) ? true : false;
        }
    }
}
