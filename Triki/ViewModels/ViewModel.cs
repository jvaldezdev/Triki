using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Triki.Models;
using Triki.Views;

namespace Triki.ViewModels
{
    class ViewModel : ObservableCollection<Model>, INotifyPropertyChanged
    {
        #region Atributos
        public bool turno = false;
        public int movimientos = 9;
        public int numRondas = 1;
        public int victoria1 = 0;
        public int victoria2 = 0;
        public int derrota1 = 0;
        public int derrota2 = 0;
        public int emp = 0;
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
        private int victoriaX = 0;
        private int victoriaO = 0;
        private int derrotaX = 0;
        private int derrotaO = 0;
        private int empate = 0;
        private ICommand iniciarEstadisticas;
        private ICommand marcar1;
        private ICommand marcar2;
        private ICommand marcar3;
        private ICommand marcar4;
        private ICommand marcar5;
        private ICommand marcar6;
        private ICommand marcar7;
        private ICommand marcar8;
        private ICommand marcar9;
        private ICommand limpiar;
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
        public ICommand IniciarEstadisticas
        {
            get { return iniciarEstadisticas; }
            set { iniciarEstadisticas = value; }
        }
        public ICommand Marcar1
        {
            get { return marcar1; }
            set { marcar1 = value; }
        }
        public ICommand Marcar2
        {
            get { return marcar2; }
            set { marcar2 = value; }
        }
        public ICommand Marcar3
        {
            get { return marcar3; }
            set { marcar3 = value; }
        }
        public ICommand Marcar4
        {
            get { return marcar4; }
            set { marcar4 = value; }
        }
        public ICommand Marcar5
        {
            get { return marcar5; }
            set { marcar5 = value; }
        }
        public ICommand Marcar6
        {
            get { return marcar6; }
            set { marcar6 = value; }
        }
        public ICommand Marcar7
        {
            get { return marcar7; }
            set { marcar7 = value; }
        }
        public ICommand Marcar8
        {
            get { return marcar8; }
            set { marcar8 = value; }
        }
        public ICommand Marcar9
        {
            get { return marcar9; }
            set { marcar9 = value; }
        }
        public ICommand Limpiar
        {
            get { return limpiar; }
            set { limpiar = value; }
        }
        #endregion

        #region Constructores
        public ViewModel()
        {
            IniciarEstadisticas = new CommandBase(param => this.CargarDatos());
            Ronda = "Ronda " + numRondas;
            Marcar1 = new CommandBase(new Action<object>(AgregarMarca1));
            Marcar2 = new CommandBase(new Action<object>(AgregarMarca2));
            Marcar3 = new CommandBase(new Action<object>(AgregarMarca3));
            Marcar4 = new CommandBase(new Action<object>(AgregarMarca4));
            Marcar5 = new CommandBase(new Action<object>(AgregarMarca5));
            Marcar6 = new CommandBase(new Action<object>(AgregarMarca6));
            Marcar7 = new CommandBase(new Action<object>(AgregarMarca7));
            Marcar8 = new CommandBase(new Action<object>(AgregarMarca8));
            Marcar9 = new CommandBase(new Action<object>(AgregarMarca9));
            Limpiar = new CommandBase(new Action<object>(LimpiarCampos));
        }
        #endregion

        #region Interface
        public new event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region Metodos/Funciones
        private void CargarDatos()
        {
            Model info = new Model
            {
                VictoriaX = VictoriaX,
                VictoriaO = VictoriaO,
                DerrotaX = DerrotaX,
                DerrotaO = DerrotaO,
                Empate = Empate
            };
            this.Add(info);
        }
        private void AgregarMarca1(object obj) 
        { 
            if (turno == false && string.IsNullOrEmpty(Cuadro1)) { Cuadro1 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro1)) { Cuadro1 = "O"; Turnos(false); }
        }
        private void AgregarMarca2(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro2)) { Cuadro2 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro2)) { Cuadro2 = "O"; Turnos(false); }
        }
        private void AgregarMarca3(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro3)) { Cuadro3 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro3)) { Cuadro3 = "O"; Turnos(false); }
        }
        private void AgregarMarca4(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro4)) { Cuadro4 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro4)) { Cuadro4 = "O"; Turnos(false); }
        }
        private void AgregarMarca5(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro5)) { Cuadro5 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro5)) { Cuadro5 = "O"; Turnos(false); }
        }
        private void AgregarMarca6(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro6)) { Cuadro6 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro6)) { Cuadro6 = "O"; Turnos(false); }
        }
        private void AgregarMarca7(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro7)) { Cuadro7 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro7)) { Cuadro7 = "O"; Turnos(false); }
        }
        private void AgregarMarca8(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro8)) { Cuadro8 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro8)) { Cuadro8 = "O"; Turnos(false); }
        }
        private void AgregarMarca9(object obj)
        {
            if (turno == false && string.IsNullOrEmpty(Cuadro9)) { Cuadro9 = "X"; Turnos(true); }
            else if (turno == true && string.IsNullOrEmpty(Cuadro9)) { Cuadro9 = "O"; Turnos(false); }
        }
        private void LimpiarCampos(object obj)
        {
            if (movimientos > 1)
            {
                if (Dialogo("¿Seguro que desea reiniciar?", "") == MessageBoxResult.Yes)
                {
                    Cuadro1 = Cuadro2 = Cuadro3 = Cuadro4 = Cuadro5 = Cuadro6 = Cuadro7 = Cuadro8 = Cuadro9 = "";
                    numRondas += 1;
                    movimientos = 9;
                }
            }
        }

        private void Turnos(bool t)
        {
            turno = t;
            movimientos -= 1;
            if ((cuadro1 == "X" && cuadro2 == "X" && Cuadro3 == "X") || (cuadro4 == "X" && cuadro5 == "X" && Cuadro6 == "X") || (cuadro7 == "X" && cuadro8 == "X" && Cuadro9 == "X")
                || (cuadro1 == "X" && cuadro4 == "X" && Cuadro7 == "X") || (cuadro2 == "X" && cuadro5 == "X" && Cuadro8 == "X") || (cuadro3 == "X" && cuadro6 == "X" && Cuadro9 == "X")
                || (cuadro1 == "X" && cuadro5 == "X" && Cuadro9 == "X")|| (cuadro3 == "X" && cuadro5 == "X" && Cuadro7 == "X")) 
            {
                VictoriaX = DerrotaO = victoria1 = derrota2 += 1;
                if (Dialogo("X es el ganador" + Environment.NewLine + "¿Desea jugar otra ronda?", "") == MessageBoxResult.Yes)
                {
                    Cuadro1 = Cuadro2 = Cuadro3 = Cuadro4 = Cuadro5 = Cuadro6 = Cuadro7 = Cuadro8 = Cuadro9 = "";
                    numRondas += 1;
                    Ronda = "Ronda " + numRondas;
                    movimientos = 9;
                }
            }
            else if ((cuadro1 == "O" && cuadro2 == "O" && Cuadro3 == "O") || (cuadro4 == "O" && cuadro5 == "O" && Cuadro6 == "O") || (cuadro7 == "O" && cuadro8 == "O" && Cuadro9 == "O")
               || (cuadro1 == "O" && cuadro4 == "O" && Cuadro7 == "O") || (cuadro2 == "O" && cuadro5 == "O" && Cuadro8 == "O") || (cuadro3 == "O" && cuadro6 == "O" && Cuadro9 == "O")
               || (cuadro1 == "O" && cuadro5 == "O" && Cuadro9 == "O") || (cuadro3 == "O" && cuadro5 == "O" && Cuadro7 == "O"))
            {
                VictoriaO = DerrotaX = victoria2 = derrota1 += 1;
                if (Dialogo("O es el ganador" + Environment.NewLine + "¿Desea jugar otra ronda?", "") == MessageBoxResult.Yes)
                {
                    Cuadro1 = Cuadro2 = Cuadro3 = Cuadro4 = Cuadro5 = Cuadro6 = Cuadro7 = Cuadro8 = Cuadro9 = "";
                    numRondas += 1;
                    Ronda = "Ronda " + numRondas;
                    movimientos = 9;
                }
            }
            else if (movimientos == 0)
            {
                Empate = emp += 1;
                if (Dialogo("¡Empate!" + Environment.NewLine + "¿Desea jugar otra ronda?", "") == MessageBoxResult.Yes)
                {
                    Cuadro1 = Cuadro2 = Cuadro3 = Cuadro4 = Cuadro5 = Cuadro6 = Cuadro7 = Cuadro8 = Cuadro9 = "";
                    numRondas += 1;
                    Ronda = "Ronda " + numRondas;
                    movimientos = 9;
                }
            }
        }

        private MessageBoxResult Dialogo(string mensaje, string c)
        {
            return MessageBox.Show(mensaje, c, MessageBoxButton.YesNo);
        }
        #endregion
    }
}