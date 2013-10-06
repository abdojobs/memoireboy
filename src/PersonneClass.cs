using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoireBoy2013
{
    public class PersonneClass
    {
        private int _idPers;

        internal int idPers {
            get { return _idPers; }
            set { _idPers = value; }
        }
        internal string civilite { get; set; }
        internal string prenom { get; set; }
        internal string nom { get; set; }
        internal string dateNaissance { get; set; }

        private string Email;
        internal string e_mail
        {
            get { return Email; }
            set { if (FormaterEmail(value)) { Email = value; } }
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
			this.idPers = cidPers;
            this.civilite = cciv;
            this.prenom = FormaterPn(cpn);
            this.nom = FormaterNom(cnom);
			this.dateNaissance = cdatenaiss;
            this.e_mail = email;
            this.telfixe = FormaterTel(ctelfixe);
            this.telportable = FormaterTel(ctelmobile);
			this.fax=cfax;
            this.adresse = cadr;
            this.cp = ccp;
			this.ville = FormaterNom(cville);
            this.bp = cbp;
            this.adrImage = pathImage;
			this.note=cnote;
            this.adrDocCV = cadrCV;
            this.site = csite;
            this.activite = cactiv;
		}

                private string miseEnFormeAffichage()
                {
                    string affiche = "";
                    string format_fix = "";
                    string format_mob = "";
                    string civ = " ";
                    string pren = "";

                    if (telfixe != "") { format_fix = "[" + telfixe + "] "; }
                    if (telportable != "") { format_mob = " [" + telportable + "] "; }
                    if (civilite != "") { civ = "  (" + civilite + ")  "; }
                    if (prenom != "") { pren = " "; }

                    affiche = prenom + pren + nom + civ + format_fix + format_mob + e_mail;

                    return affiche;
                }

                private string miseEnFormeAffichagePourTxt()
                {
                    string affiche = "";

                    affiche = "(" + civilite + ")," + prenom + "," + nom + "," + telfixe + "," + telportable +"," + e_mail;

                    return affiche;
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
                    string num = "";

                    for (int i = 0; i < tel.Length; i++)
                    {
                        for (int j = 0; j < chiffre.Length; j++)
                        {
                            if (tel[i] == chiffre[j])
                            {
                                num += tel[i].ToString(); break;
                            }

                        }
                    }

                    if (num.Length == 9) { num = num.Insert(0, "0"); }

                    char[] cptChiffres = num.ToCharArray();
                    string NewNum = "";
                    if (cptChiffres.Length == 10)
                    {
                        for (int p = 0; p < cptChiffres.Length; p++)
                        {
                           // if (p == 2 || p == 4 || p == 6 || p == 8) { NewNum += "."; }
                            NewNum += cptChiffres[p].ToString();
                        }

                    }

                    return NewNum;

                }


                public static bool FormaterEmail(string mail)
                {
                    if (mail.Contains('@')&&(mail.Contains('.')))
                    { return true; }
                    else
                    {
                        return false;
                    }

                }

    }
}
