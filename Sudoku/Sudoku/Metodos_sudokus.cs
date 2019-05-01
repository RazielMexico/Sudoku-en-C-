using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Metodos_sudokus
    {
        Random rnd = new Random();
        //METODOS DEL DATAGIRDVIEW
        public DataGridView limpiar_datagird(DataGridView Tabla)
        {
            Tabla.Columns.Clear();
            Tabla.Rows.Clear();
            Tabla.ClearSelection();
            return Tabla;
        }

        public DataGridView crear_filas_datagird(DataGridView Tabla, int N_fil)
        {
            for (int x = 0; x < N_fil; x++)
            {
                Tabla.Rows.Add();
            }
            return Tabla;
        }

        public DataGridView crear_columnas_datagird(DataGridView Tabla, int N_colu)
        {
            for (int x = 0; x < N_colu; x++)
            {
                Tabla.Columns.Add(Convert.ToString(x), null);
            }
            return Tabla;
        }

        public DataGridView pintar_datagird(DataGridView Tabla, int Col_final, int fila_final, int Col_inicial, int fila_inicial, bool rojo)
        {
            if (rojo == true)
            {
                for (int x = fila_inicial; x < fila_final; x++)
                {
                    for (int y = Col_inicial; y < Col_final; y++)
                    {
                        Tabla.Rows[x].Cells[y].Style.BackColor = Color.Green;
                    }

                }
            }
            else
            {
                for (int x = fila_inicial; x < fila_final; x++)
                {
                    for (int y = Col_inicial; y < Col_final; y++)
                    {
                        Tabla.Rows[x].Cells[y].Style.BackColor = Color.White;
                    }

                }
            }
            return Tabla;
        }

        public DataGridView Llenar_datagird(DataGridView Tabla)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Tabla.Rows[x].Cells[y].Value = Convert.ToString(random());
                }

            }
            return Tabla;
        }

        public int contador_datos(DataGridView Tabla)
        {
            int contador = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (Tabla.Rows[y].Cells[x].Value.ToString() != string.Empty)
                    {
                        contador++;
                    }
                }

            }
            return contador;
        }


        //Metodo de Cronometro

        void Parar_tiempo()
        {

        }

        //METODOS RANDOM 
        public int random()
        {
            int a = rnd.Next(0, 10);
            return a;
        }

        public int randomsudoku()
        {
            int a = rnd.Next(1, 5);
            return a;
        }
        //reglas del sudoku

        //regla 1: las regiones 3 x 3 no tiene que haber ningun numero pepetido 
        public DataGridView regla1(DataGridView Tabla, int Col_inicial, int Col_final, int fila_inicial, int fila_final)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
            {
                for (int x = fila_inicial; x < fila_final; x++)
                {
                    for (int y = Col_inicial; y < Col_final; y++)
                    {
                        if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                        {
                            contador++;
                        }
                        if (contador > 1)
                        {
                            Tabla.Rows[x].Cells[y].Style.BackColor = Color.Red;
                            contador = 1;
                            //Correcto = false;
                        }
                    }
                }
                contador = 0;
            }
            return Tabla;
        }


        public DataGridView regla1_llenado(DataGridView Tabla, int Col_inicial, int Col_final, int fila_inicial, int fila_final)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
            {
                for (int x = fila_inicial; x < fila_final; x++)
                {
                    for (int y = Col_inicial; y < Col_final; y++)
                    {
                        if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                        {
                            contador++;
                        }
                        if (contador > 1)
                        {
                            Tabla.Rows[x].Cells[y].Value = string.Empty;
                            contador = 1;
                        }
                    }

                }
                contador = 0;
            }
            return Tabla;
        }


        //regla 2: En ninguna columna tiene que estar el mismo numero 2 veces 
        public DataGridView regla2(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                    {
                        contador++;
                    }
                    if (contador > 1)
                    {
                        Tabla.Rows[x].Cells[y].Style.BackColor = Color.Yellow;
                        contador = 1;
                        //Correcto = false;
                    }
                }
                contador = 0;
            }

            return Tabla;
        }

        public DataGridView regla2_llenado(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                    {
                        contador++;
                    }
                    if (contador > 1)
                    {
                        Tabla.Rows[x].Cells[y].Value = string.Empty;
                        contador = 1;
                    }
                }
                contador = 0;
            }
            return Tabla;
        }


        //regla 3: En ninguna fila tiene que estar el mismo numero 2 veces 
        //y = fila
        public DataGridView regla3(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Tabla.Rows[y].Cells[x].Value.ToString() == Convert.ToString(casilla))
                    {
                        contador++;
                    }
                    if (contador > 1)
                    {
                        Tabla.Rows[y].Cells[x].Style.BackColor = Color.Orange;
                        contador = 1;
                        //Correcto = false;
                    }
                }
                contador = 0;
            }

            return Tabla;
        }

        public DataGridView regla3_llenado(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Tabla.Rows[y].Cells[x].Value.ToString() == Convert.ToString(casilla))
                    {
                        contador++;
                    }
                    if (contador > 1)
                    {
                        Tabla.Rows[y].Cells[x].Value = string.Empty;
                        contador = 1;
                    }
                }
                contador = 0;
            }
            return Tabla;
        }



        //regla 4: No puede tener casilla vacias 
        public DataGridView regla4(DataGridView Tabla)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Tabla.Rows[y].Cells[x].Value.ToString() == string.Empty || Tabla.Rows[y].Cells[x].Value.ToString() == "")
                    {
                        Tabla.Rows[y].Cells[x].Style.BackColor = Color.Purple;
                        //Correcto = false;
                    }

                }

            }

            return Tabla;
        }

        string[,] arreglo = new string[10, 10];

        int[,] arreglo1 = new int[10, 10];

        public DataGridView llenarArreglo(DataGridView tabla)
        {
            arreglo1[0, 0] = 4;
            arreglo1[0, 1] = 3;
            arreglo1[0, 2] = 5;
            arreglo1[0, 3] = 8;
            arreglo1[0, 4] = 2;
            arreglo1[0, 5] = 1;
            arreglo1[0, 6] = 9;
            arreglo1[0, 7] = 7;
            arreglo1[0, 8] = 6;

            arreglo1[1, 0] = 7;
            arreglo1[1, 1] = 9;
            arreglo1[1, 2] = 1;
            arreglo1[1, 3] = 4;
            arreglo1[1, 4] = 6;
            arreglo1[1, 5] = 3;
            arreglo1[1, 6] = 8;
            arreglo1[1, 7] = 2;
            arreglo1[1, 8] = 5;

            arreglo1[2, 0] = 2;
            arreglo1[2, 1] = 6;
            arreglo1[2, 2] = 8;
            arreglo1[2, 3] = 7;
            arreglo1[2, 4] = 5;
            arreglo1[2, 5] = 9;
            arreglo1[2, 6] = 4;
            arreglo1[2, 7] = 3;
            arreglo1[2, 8] = 1;

            arreglo1[3, 0] = 9;
            arreglo1[3, 1] = 1;
            arreglo1[3, 2] = 7;
            arreglo1[3, 3] = 3;
            arreglo1[3, 4] = 4;
            arreglo1[3, 5] = 6;
            arreglo1[3, 6] = 2;
            arreglo1[3, 7] = 5;
            arreglo1[3, 8] = 8;

            arreglo1[4, 0] = 3;
            arreglo1[4, 1] = 5;
            arreglo1[4, 2] = 6;
            arreglo1[4, 3] = 9;
            arreglo1[4, 4] = 8;
            arreglo1[4, 5] = 2;
            arreglo1[4, 6] = 1;
            arreglo1[4, 7] = 4;
            arreglo1[4, 8] = 7;

            arreglo1[5, 0] = 8;
            arreglo1[5, 1] = 4;
            arreglo1[5, 2] = 2;
            arreglo1[5, 3] = 1;
            arreglo1[5, 4] = 7;
            arreglo1[5, 5] = 5;
            arreglo1[5, 6] = 6;
            arreglo1[5, 7] = 9;
            arreglo1[5, 8] = 3;

            arreglo1[6, 0] = 5;
            arreglo1[6, 1] = 7;
            arreglo1[6, 2] = 9;
            arreglo1[6, 3] = 6;
            arreglo1[6, 4] = 1;
            arreglo1[6, 5] = 4;
            arreglo1[6, 6] = 3;
            arreglo1[6, 7] = 8;
            arreglo1[6, 8] = 2;

            arreglo1[7, 0] = 1;
            arreglo1[7, 1] = 8;
            arreglo1[7, 2] = 4;
            arreglo1[7, 3] = 2;
            arreglo1[7, 4] = 3;
            arreglo1[7, 5] = 7;
            arreglo1[7, 6] = 5;
            arreglo1[7, 7] = 6;
            arreglo1[7, 8] = 9;

            arreglo1[8, 0] = 6;
            arreglo1[8, 1] = 2;
            arreglo1[8, 2] = 3;
            arreglo1[8, 3] = 5;
            arreglo1[8, 4] = 9;
            arreglo1[8, 5] = 8;
            arreglo1[8, 6] = 7;
            arreglo1[8, 7] = 1;
            arreglo1[8, 8] = 4;

            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    tabla.Rows[y].Cells[x].Value = Convert.ToString(arreglo1[y, x]);
                }
            }

            return tabla;
        }

        public DataGridView llenarArreglo1(DataGridView tabla)
        {
            arreglo1[0, 0] = 8;
            arreglo1[0, 1] = 6;
            arreglo1[0, 2] = 7;
            arreglo1[0, 3] = 1;
            arreglo1[0, 4] = 4;
            arreglo1[0, 5] = 5;
            arreglo1[0, 6] = 2;
            arreglo1[0, 7] = 9;
            arreglo1[0, 8] = 3;

            arreglo1[1, 0] = 9;
            arreglo1[1, 1] = 1;
            arreglo1[1, 2] = 5;
            arreglo1[1, 3] = 7;
            arreglo1[1, 4] = 2;
            arreglo1[1, 5] = 3;
            arreglo1[1, 6] = 8;
            arreglo1[1, 7] = 6;
            arreglo1[1, 8] = 4;

            arreglo1[2, 0] = 4;
            arreglo1[2, 1] = 2;
            arreglo1[2, 2] = 3;
            arreglo1[2, 3] = 8;
            arreglo1[2, 4] = 6;
            arreglo1[2, 5] = 9;
            arreglo1[2, 6] = 5;
            arreglo1[2, 7] = 7;
            arreglo1[2, 8] = 1;

            arreglo1[3, 0] = 1;
            arreglo1[3, 1] = 7;
            arreglo1[3, 2] = 9;
            arreglo1[3, 3] = 3;
            arreglo1[3, 4] = 8;
            arreglo1[3, 5] = 4;
            arreglo1[3, 6] = 6;
            arreglo1[3, 7] = 2;
            arreglo1[3, 8] = 5;

            arreglo1[4, 0] = 6;
            arreglo1[4, 1] = 3;
            arreglo1[4, 2] = 4;
            arreglo1[4, 3] = 2;
            arreglo1[4, 4] = 5;
            arreglo1[4, 5] = 7;
            arreglo1[4, 6] = 1;
            arreglo1[4, 7] = 8;
            arreglo1[4, 8] = 9;

            arreglo1[5, 0] = 5;
            arreglo1[5, 1] = 8;
            arreglo1[5, 2] = 2;
            arreglo1[5, 3] = 6;
            arreglo1[5, 4] = 9;
            arreglo1[5, 5] = 1;
            arreglo1[5, 6] = 3;
            arreglo1[5, 7] = 4;
            arreglo1[5, 8] = 7;

            arreglo1[6, 0] = 2;
            arreglo1[6, 1] = 5;
            arreglo1[6, 2] = 1;
            arreglo1[6, 3] = 4;
            arreglo1[6, 4] = 7;
            arreglo1[6, 5] = 8;
            arreglo1[6, 6] = 9;
            arreglo1[6, 7] = 3;
            arreglo1[6, 8] = 6;

            arreglo1[7, 0] = 7;
            arreglo1[7, 1] = 9;
            arreglo1[7, 2] = 6;
            arreglo1[7, 3] = 5;
            arreglo1[7, 4] = 3;
            arreglo1[7, 5] = 2;
            arreglo1[7, 6] = 4;
            arreglo1[7, 7] = 1;
            arreglo1[7, 8] = 8;

            arreglo1[8, 0] = 3;
            arreglo1[8, 1] = 4;
            arreglo1[8, 2] = 8;
            arreglo1[8, 3] = 9;
            arreglo1[8, 4] = 1;
            arreglo1[8, 5] = 6;
            arreglo1[8, 6] = 7;
            arreglo1[8, 7] = 5;
            arreglo1[8, 8] = 2;

            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    tabla.Rows[y].Cells[x].Value = Convert.ToString(arreglo1[y, x]);
                }
            }

            return tabla;
        }

        public DataGridView llenarArreglo2(DataGridView tabla)
        {
            arreglo1[0, 0] = 7;
            arreglo1[0, 1] = 3;
            arreglo1[0, 2] = 9;
            arreglo1[0, 3] = 4;
            arreglo1[0, 4] = 5;
            arreglo1[0, 5] = 6;
            arreglo1[0, 6] = 1;
            arreglo1[0, 7] = 2;
            arreglo1[0, 8] = 8;

            arreglo1[1, 0] = 4;
            arreglo1[1, 1] = 2;
            arreglo1[1, 2] = 1;
            arreglo1[1, 3] = 7;
            arreglo1[1, 4] = 9;
            arreglo1[1, 5] = 8;
            arreglo1[1, 6] = 6;
            arreglo1[1, 7] = 3;
            arreglo1[1, 8] = 5;

            arreglo1[2, 0] = 6;
            arreglo1[2, 1] = 5;
            arreglo1[2, 2] = 8;
            arreglo1[2, 3] = 1;
            arreglo1[2, 4] = 2;
            arreglo1[2, 5] = 3;
            arreglo1[2, 6] = 4;
            arreglo1[2, 7] = 7;
            arreglo1[2, 8] = 9;

            arreglo1[3, 0] = 5;
            arreglo1[3, 1] = 8;
            arreglo1[3, 2] = 6;
            arreglo1[3, 3] = 3;
            arreglo1[3, 4] = 7;
            arreglo1[3, 5] = 9;
            arreglo1[3, 6] = 2;
            arreglo1[3, 7] = 4;
            arreglo1[3, 8] = 1;

            arreglo1[4, 0] = 1;
            arreglo1[4, 1] = 7;
            arreglo1[4, 2] = 3;
            arreglo1[4, 3] = 2;
            arreglo1[4, 4] = 4;
            arreglo1[4, 5] = 5;
            arreglo1[4, 6] = 8;
            arreglo1[4, 7] = 9;
            arreglo1[4, 8] = 6;

            arreglo1[5, 0] = 2;
            arreglo1[5, 1] = 9;
            arreglo1[5, 2] = 4;
            arreglo1[5, 3] = 6;
            arreglo1[5, 4] = 8;
            arreglo1[5, 5] = 1;
            arreglo1[5, 6] = 7;
            arreglo1[5, 7] = 5;
            arreglo1[5, 8] = 3;

            arreglo1[6, 0] = 9;
            arreglo1[6, 1] = 6;
            arreglo1[6, 2] = 2;
            arreglo1[6, 3] = 5;
            arreglo1[6, 4] = 1;
            arreglo1[6, 5] = 7;
            arreglo1[6, 6] = 3;
            arreglo1[6, 7] = 8;
            arreglo1[6, 8] = 4;

            arreglo1[7, 0] = 8;
            arreglo1[7, 1] = 1;
            arreglo1[7, 2] = 7;
            arreglo1[7, 3] = 9;
            arreglo1[7, 4] = 3;
            arreglo1[7, 5] = 4;
            arreglo1[7, 6] = 5;
            arreglo1[7, 7] = 6;
            arreglo1[7, 8] = 2;

            arreglo1[8, 0] = 3;
            arreglo1[8, 1] = 4;
            arreglo1[8, 2] = 5;
            arreglo1[8, 3] = 8;
            arreglo1[8, 4] = 6;
            arreglo1[8, 5] = 2;
            arreglo1[8, 6] = 9;
            arreglo1[8, 7] = 1;
            arreglo1[8, 8] = 7;

            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    tabla.Rows[y].Cells[x].Value = Convert.ToString(arreglo1[y, x]);
                }
            }

            return tabla;
        }

        public DataGridView llenarArreglo3(DataGridView tabla)
        {
            arreglo1[0, 0] = 4;
            arreglo1[0, 1] = 3;
            arreglo1[0, 2] = 1;
            arreglo1[0, 3] = 9;
            arreglo1[0, 4] = 5;
            arreglo1[0, 5] = 2;
            arreglo1[0, 6] = 8;
            arreglo1[0, 7] = 6;
            arreglo1[0, 8] = 7;

            arreglo1[1, 0] = 6;
            arreglo1[1, 1] = 9;
            arreglo1[1, 2] = 7;
            arreglo1[1, 3] = 4;
            arreglo1[1, 4] = 3;
            arreglo1[1, 5] = 8;
            arreglo1[1, 6] = 2;
            arreglo1[1, 7] = 1;
            arreglo1[1, 8] = 5;

            arreglo1[2, 0] = 5;
            arreglo1[2, 1] = 8;
            arreglo1[2, 2] = 2;
            arreglo1[2, 3] = 1;
            arreglo1[2, 4] = 6;
            arreglo1[2, 5] = 7;
            arreglo1[2, 6] = 3;
            arreglo1[2, 7] = 4;
            arreglo1[2, 8] = 9;

            arreglo1[3, 0] = 3;
            arreglo1[3, 1] = 7;
            arreglo1[3, 2] = 5;
            arreglo1[3, 3] = 2;
            arreglo1[3, 4] = 1;
            arreglo1[3, 5] = 6;
            arreglo1[3, 6] = 4;
            arreglo1[3, 7] = 9;
            arreglo1[3, 8] = 8;

            arreglo1[4, 0] = 1;
            arreglo1[4, 1] = 4;
            arreglo1[4, 2] = 6;
            arreglo1[4, 3] = 8;
            arreglo1[4, 4] = 9;
            arreglo1[4, 5] = 3;
            arreglo1[4, 6] = 7;
            arreglo1[4, 7] = 5;
            arreglo1[4, 8] = 2;

            arreglo1[5, 0] = 8;
            arreglo1[5, 1] = 2;
            arreglo1[5, 2] = 9;
            arreglo1[5, 3] = 5;
            arreglo1[5, 4] = 7;
            arreglo1[5, 5] = 4;
            arreglo1[5, 6] = 1;
            arreglo1[5, 7] = 3;
            arreglo1[5, 8] = 6;

            arreglo1[6, 0] = 7;
            arreglo1[6, 1] = 1;
            arreglo1[6, 2] = 4;
            arreglo1[6, 3] = 6;
            arreglo1[6, 4] = 8;
            arreglo1[6, 5] = 5;
            arreglo1[6, 6] = 9;
            arreglo1[6, 7] = 2;
            arreglo1[6, 8] = 3;

            arreglo1[7, 0] = 9;
            arreglo1[7, 1] = 6;
            arreglo1[7, 2] = 3;
            arreglo1[7, 3] = 7;
            arreglo1[7, 4] = 2;
            arreglo1[7, 5] = 1;
            arreglo1[7, 6] = 5;
            arreglo1[7, 7] = 8;
            arreglo1[7, 8] = 4;

            arreglo1[8, 0] = 2;
            arreglo1[8, 1] = 5;
            arreglo1[8, 2] = 8;
            arreglo1[8, 3] = 3;
            arreglo1[8, 4] = 4;
            arreglo1[8, 5] = 9;
            arreglo1[8, 6] = 6;
            arreglo1[8, 7] = 7;
            arreglo1[8, 8] = 1;

            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    tabla.Rows[y].Cells[x].Value = Convert.ToString(arreglo1[y, x]);
                }
            }

            return tabla;
        }


        public void GuardarMatriz(DataGridView tabla)
        {
            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    arreglo[y, x] = tabla.Rows[y].Cells[x].Value.ToString();

                }
            }
        }

        public void LLenarMatriz(DataGridView tabla)
        {
            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    arreglo[y, x] = string.Empty;

                }
            }
        }

        public string[,] cargarMatriz(DataGridView tabla)
        {
            int x, y;
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    arreglo[y, x] = tabla.Rows[y].Cells[x].Value.ToString();
                }
            }
            return arreglo;
        }

        public DataGridView mostrarSudoku(string[,] arreglo, string dificultad, DataGridView tabla)
        {
            int x, y, z = 0;


            if (dificultad == "facil")
            {
                for (z = 0; z < 2; z++)
                {
                    for (y = 0; y < 9; y++)
                    {
                        for (x = 0; x < 9; x++)
                        {

                            if (random() == x)
                            {
                                arreglo[y, x] = string.Empty;

                            }
                        }
                    }
                }
            }
            else if (dificultad == "normal")
            {
                for (z = 0; z < 7; z++)
                {
                    for (y = 0; y < 9; y++)
                    {
                        for (x = 0; x < 9; x++)
                        {

                            if (random() == x)
                            {
                                arreglo[y, x] = string.Empty;

                            }
                        }
                    }
                }
            }
            else if (dificultad == "dificil")
            {
                for (z = 0; z < 11; z++)
                {
                    for (y = 0; y < 9; y++)
                    {
                        for (x = 0; x < 9; x++)
                        {

                            if (random() == x)
                            {
                                arreglo[y, x] = string.Empty;

                            }
                        }
                    }
                }

            }
            for (y = 0; y < 9; y++)
            {
                for (x = 0; x < 9; x++)
                {
                    tabla.Rows[y].Cells[x].Value = arreglo[y, x];
                }
            }

            return tabla;
        }




        public DataGridView colormorado(DataGridView tabla, int valor)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    regla4(tabla);
                    if (tabla.Rows[y].Cells[x].Style.BackColor == Color.Purple)
                    {
                        tabla.Rows[y].Cells[x].Value = Convert.ToString(valor);
                        int a;
                        regla1(tabla, 0, 3, 0, 3);
                        regla1(tabla, 3, 6, 0, 3);
                        regla1(tabla, 6, 9, 0, 3);
                        regla1(tabla, 0, 3, 3, 6);
                        regla1(tabla, 3, 6, 3, 6);
                        regla1(tabla, 6, 9, 3, 6);
                        regla1(tabla, 0, 3, 6, 9);
                        regla1(tabla, 3, 6, 6, 9);
                        regla1(tabla, 6, 9, 6, 9);

                        for (a = 0; a < 9; a++)
                        {
                            tabla = regla2(tabla, x);
                        }
                        for (a = 0; a < 9; a++)
                        {
                            tabla = regla3(tabla, x);
                        }
                        if (tabla.Rows[y].Cells[x].Style.BackColor == Color.Purple)
                        {
                            tabla.Rows[y].Cells[x].Style.BackColor = Color.White;
                        }
                    }
                }
            }
            return tabla;
        }
    }
}
