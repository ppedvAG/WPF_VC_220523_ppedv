﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM.Model
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        public static void LadePersonenAusDb()
        {
            Personenliste.Add(new Person() { Vorname = "Rainer", Nachname = "Zufall", Geburtsdatum = new DateTime(1987, 5, 13), Verheiratet = true, Lieblingsfarbe = Colors.DarkSeaGreen, Geschlecht = Gender.Männlich });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Nass", Geburtsdatum = new DateTime(1974, 11, 29), Verheiratet = false, Lieblingsfarbe = Colors.LightBlue, Geschlecht = Gender.Weiblich });
        }                                 



        public event PropertyChangedEventHandler? PropertyChanged;

        private string vorname;
        public string Vorname { get => vorname; set { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname))); vorname = value; } }

        private string nachname;
        public string Nachname { get => nachname; set { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nachname))); nachname = value; } }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum { get => geburtsdatum; set { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geburtsdatum))); geburtsdatum = value; } }

        private bool verheiratet;
        public bool Verheiratet { get => verheiratet; set { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Verheiratet))); verheiratet = value; } }

        private Color lieblingsfarbe;
        public Color Lieblingsfarbe { get => lieblingsfarbe; set { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieblingsfarbe))); lieblingsfarbe = value; } }

        private Gender geschlecht;
        public Gender Geschlecht { get => geschlecht; set { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geschlecht))); geschlecht = value; } }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {

                    case nameof(Vorname):
                        if (Vorname.Length == 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(CheckForLetter)) return "Der Vorname darf nur Buchstaben enthalten.";
                        if (Char.IsLower(Vorname.First())) return "Der Vorname muss mit einem Großbuchstaben beginnen";
                        break;

                    case nameof(Nachname):
                        if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
                        if (Char.IsLower(Nachname.First())) return "Der Nachname muss mit einem Großbuchstaben beginnen";
                        break;

                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;

                    case nameof(Lieblingsfarbe):
                        if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Lieblingsfarbe aus.";
                        break;
                }

                return String.Empty;
            }
        }

        private static bool CheckForLetter(char c)
        {
            return Char.IsLetter(c);
        }


        public Person()
        {
            this.vorname = String.Empty;
            this.nachname = String.Empty;
            this.Geburtsdatum = DateTime.Now;
        }

        public Person(Person altePerson)
        {
            this.vorname = altePerson.Vorname;
            this.nachname = altePerson.Nachname;
            this.geschlecht = altePerson.Geschlecht;
            this.verheiratet = altePerson.Verheiratet;
            this.lieblingsfarbe = altePerson.Lieblingsfarbe;

            this.geburtsdatum = new DateTime(altePerson.Geburtsdatum.Year, altePerson.Geburtsdatum.Month, altePerson.Geburtsdatum.Day);
        }
    }
}