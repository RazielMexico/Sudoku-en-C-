using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public static bool Correcto = true;

        DataSet ds = new DataSet();
        static Metodos_sudokus sudoku = new Metodos_sudokus();



        private void button2_Click(object sender, EventArgs e)
        {
            Correcto = true;
            timer1.Stop();
            label_milesimas.Text = "00";
            label_segundos.Text = "00";
            label_minutos.Text = "00";
            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Selecciona Una dificultad");
            }
            else
            {
                sudoku.limpiar_datagird(dgvTabla);
                dgvTabla = sudoku.crear_columnas_datagird(dgvTabla, 9);
                dgvTabla = sudoku.crear_filas_datagird(dgvTabla, 8);
                //regiones pintada
                try
                {
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 3, 0, 0, false);
                    //region 2 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 3, 3, 0, true);
                    //region 3 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 3, 6, 0, false);
                    //region 4 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 6, 0, 3, true);
                    //region 5 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 6, 3, 3, false);
                    //region 6 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 6, 6, 3, true);
                    //region 7 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 9, 0, 6, false);
                    //region 8 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 9, 3, 6, true);
                    //region 9 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 9, 6, 6, false);
                }
                catch (Exception) { }
                //llenar la matriz
                int aleatorio = 0;
                if (comboBox1.Text == "Facil")
                {
                    aleatorio = sudoku.randomsudoku();
                    if (aleatorio == 1)
                    { dgvTabla = sudoku.llenarArreglo(dgvTabla); }
                    else if (aleatorio == 2)
                    { dgvTabla = sudoku.llenarArreglo1(dgvTabla); }
                    else if (aleatorio == 3)
                    { dgvTabla = sudoku.llenarArreglo2(dgvTabla); }
                    else if (aleatorio == 4)
                    { dgvTabla = sudoku.llenarArreglo3(dgvTabla); }
                    dgvTabla = sudoku.mostrarSudoku(sudoku.cargarMatriz(dgvTabla), "facil", dgvTabla);
                    MessageBox.Show("La cantidad de datos es:" + Convert.ToString(sudoku.contador_datos(dgvTabla)));
                }
                if (comboBox1.Text == "Normal")
                {
                    aleatorio = sudoku.randomsudoku();
                    if (aleatorio == 1)
                    { dgvTabla = sudoku.llenarArreglo(dgvTabla); }
                    else if (aleatorio == 2)
                    { dgvTabla = sudoku.llenarArreglo1(dgvTabla); }
                    else if (aleatorio == 3)
                    { dgvTabla = sudoku.llenarArreglo2(dgvTabla); }
                    else if (aleatorio == 4)
                    { dgvTabla = sudoku.llenarArreglo3(dgvTabla); }
                    dgvTabla = sudoku.mostrarSudoku(sudoku.cargarMatriz(dgvTabla), "normal", dgvTabla);
                    MessageBox.Show("La cantidad de datos es:" + Convert.ToString(sudoku.contador_datos(dgvTabla)));
                }
                if (comboBox1.Text == "Dificil")
                {
                    aleatorio = sudoku.randomsudoku();
                    if (aleatorio == 1)
                    { dgvTabla = sudoku.llenarArreglo(dgvTabla); }
                    else if (aleatorio == 2)
                    { dgvTabla = sudoku.llenarArreglo1(dgvTabla); }
                    else if (aleatorio == 3)
                    { dgvTabla = sudoku.llenarArreglo2(dgvTabla); }
                    else if (aleatorio == 4)
                    { dgvTabla = sudoku.llenarArreglo3(dgvTabla); }
                    dgvTabla = sudoku.mostrarSudoku(sudoku.cargarMatriz(dgvTabla), "dificil", dgvTabla);
                    MessageBox.Show("La cantidad de datos es:" + Convert.ToString(sudoku.contador_datos(dgvTabla)));
                }
                timer1.Start();
                button1.Enabled = true;
                button3.Enabled = true;
                btnVerificar.Enabled = true;
                button4.Enabled = true;
                
            }
        }

        
        private void btnVerificar_Click_1(object sender, EventArgs e)
        {
            try
            {

                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 3, 0, 0, false);
                //region 2 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 3, 3, 0, true);
                //region 3 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 3, 6, 0, false);
                //region 4 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 6, 0, 3, true);
                //region 5 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 6, 3, 3, false);
                //region 6 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 6, 6, 3, true);
                //region 7 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 9, 0, 6, false);
                //region 8 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 9, 3, 6, true);
                //region 9 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 9, 6, 6, false);
            }
            catch (Exception) { }
            //llenar la matriz
            Correcto = true;
            int x;
            try
            {
                dgvTabla = sudoku.regla1(dgvTabla, 0, 3, 0, 3);
                dgvTabla = sudoku.regla1(dgvTabla, 3, 6, 0, 3);
                dgvTabla = sudoku.regla1(dgvTabla, 6, 9, 0, 3);
                dgvTabla = sudoku.regla1(dgvTabla, 0, 3, 3, 6);
                dgvTabla = sudoku.regla1(dgvTabla, 3, 6, 3, 6);
                dgvTabla = sudoku.regla1(dgvTabla, 6, 9, 3, 6);
                dgvTabla = sudoku.regla1(dgvTabla, 0, 3, 6, 9);
                dgvTabla = sudoku.regla1(dgvTabla, 3, 6, 6, 9);
                dgvTabla = sudoku.regla1(dgvTabla, 6, 9, 6, 9);
            }
            catch (Exception)
            {

            }
            try
            {
                for (x = 0; x < 9; x++)
                {
                    dgvTabla = sudoku.regla2(dgvTabla, x);
                }
            }
            catch (Exception) { }
            try
            {
                for (x = 0; x < 9; x++)
                {
                    dgvTabla = sudoku.regla3(dgvTabla, x);
                }
            }
            catch (Exception)
            {

            }
            try
            {
                dgvTabla = sudoku.regla4(dgvTabla);
            }
            catch (Exception) { }

            if (Correcto)
            {
                MessageBox.Show("Felicidades has Ganado");
            }
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 3, 0, 0, false);
                //region 2 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 3, 3, 0, true);
                //region 3 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 3, 6, 0, false);
                //region 4 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 6, 0, 3, true);
                //region 5 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 6, 3, 3, false);
                //region 6 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 6, 6, 3, true);
                //region 7 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 9, 0, 6, false);
                //region 8 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 9, 3, 6, true);
                //region 9 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 9, 6, 6, false);
            }
            catch (Exception) { }
            //llenar la matriz
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            int milesima, segundo, minuto;
            milesima = Convert.ToInt32(label_milesimas.Text);
            milesima += 1;
            label_milesimas.Text = milesima.ToString();
            if (milesima == 60)
            {
                segundo = Convert.ToInt32(label_segundos.Text);
                segundo += 1;
                label_segundos.Text = segundo.ToString();
                label_milesimas.Text = "00";
                if (segundo == 60)
                {
                    minuto = Convert.ToInt32(label_minutos.Text);
                    minuto += 1;
                    label_minutos.Text = minuto.ToString();
                    label_segundos.Text = "00";
                }
            }
        }
    }
}
