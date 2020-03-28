namespace Triki.Models
{
    class Model : NotifyBase
    {
        #region Atributos
        private string cuadro1;
        private string cuadro2;
        private string cuadro3;
        private string cuadro4;
        private string cuadro5;
        private string cuadro6;
        private string cuadro7;
        private string cuadro8;
        private string cuadro9;
        private string ronda;
        private int victoriaX;
        private int victoriaO;
        private int derrotaX;
        private int derrotaO;
        private int empate;
        #endregion

        #region Propiedades
        public string Cuadro1
        {
            get { return cuadro1; }
            set { cuadro1 = value; OnPropertyChanged("Cuadro1"); }
        }
        public string Cuadro2
        {
            get { return cuadro2; }
            set { cuadro2 = value; OnPropertyChanged("Cuadro2"); }
        }
        public string Cuadro3
        {
            get { return cuadro3; }
            set { cuadro3 = value; OnPropertyChanged("Cuadro3"); }
        }
        public string Cuadro4
        {
            get { return cuadro4; }
            set { cuadro4 = value; OnPropertyChanged("Cuadro4"); }
        }
        public string Cuadro5
        {
            get { return cuadro5; }
            set { cuadro5 = value; OnPropertyChanged("Cuadro5"); }
        }
        public string Cuadro6
        {
            get { return cuadro6; }
            set { cuadro6 = value; OnPropertyChanged("Cuadro6"); }
        }
        public string Cuadro7
        {
            get { return cuadro7; }
            set { cuadro7 = value; OnPropertyChanged("Cuadro7"); }
        }
        public string Cuadro8
        {
            get { return cuadro8; }
            set { cuadro8 = value; OnPropertyChanged("Cuadro8"); }
        }
        public string Cuadro9
        {
            get { return cuadro9; }
            set { cuadro9 = value; OnPropertyChanged("Cuadro9"); }
        }
        public string Ronda
        {
            get { return ronda; }
            set { ronda = value; OnPropertyChanged("Ronda"); }
        }
        public int VictoriaX
        {
            get { return victoriaX; }
            set { victoriaX = value; OnPropertyChanged("VictoriaX"); }
        }
        public int VictoriaO
        {
            get { return victoriaO; }
            set { victoriaO = value; OnPropertyChanged("VictoriaO"); }
        }
        public int DerrotaX
        {
            get { return derrotaX; }
            set { derrotaX = value; OnPropertyChanged("DerrotaX"); }
        }
        public int DerrotaO
        {
            get { return derrotaO; }
            set { derrotaO = value; OnPropertyChanged("DerrotaO"); }
        }
        public int Empate
        {
            get { return empate; }
            set { empate = value; OnPropertyChanged("Empate"); }
        }
        #endregion
    }
}
