using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmTateti
{
    public partial class FrmTateti : Form
    {
        Button[] listaBotones = new Button[9];
        
        public FrmTateti()
        {
            InitializeComponent();
            List<Button> c;
            int j = 0;
            c = Controls.OfType<Button>().ToList(); //AGREGA TODOS LOS BOTONOES A LA LISTA
            for (int i = 8; i >= 0; i--) //SE AGREGA RECORRIENDO LA LISTA A LA IVERSA PORQUE LOS BOTONES ASI FUERON AGREGADOS
            {
                listaBotones[j] = c.ElementAt(i);
                j++;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            if (boton.Text == "")
            {
                boton.Text = "X";
                boton.BackColor = Color.Aqua;
                boton.Enabled = false;
                if(Chequear("X") == false) //SI NO SE GANO JUEGA MAQUINA
                {
                    if(this.existeLugar()) 
                    {
                        this.ClickEnemigo();
                        if(Chequear("O") == false)
                        {
                            if(this.existeLugar() == false)
                            {
                                MessageBox.Show("Empate");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Perdiste");
                            this.Reiniciar();
                        }
                    }
                    else //SI NO HYA MAS LUGAR SE REINICIA
                    {
                        MessageBox.Show("Empate");
                        this.Reiniciar();
                    }
                }
                else
                {
                    MessageBox.Show("GANASTE");
                    this.Reiniciar();
                }
                

            }
        }
        
        private bool Chequear(string letra)
        {
            //FILAS
            if(btn1.Text == letra && btn2.Text == letra && btn3.Text == letra)
            {
                return true;
            }

            if (btn4.Text == letra && btn5.Text == letra && btn6.Text == letra)
            {
                return true;
            }

            if (btn7.Text == letra && btn8.Text == letra && btn9.Text == letra)
            {
                return true;
            }

            //COLUMNAS
            if (btn1.Text == letra && btn4.Text == letra && btn7.Text == letra)
            {
                return true;
            }

            if (btn2.Text == letra && btn5.Text == letra && btn8.Text == letra)
            {
                return true;
            }

            if (btn3.Text == letra && btn6.Text == letra && btn9.Text == letra)
            {
                return true;
            }

            //DIAGONALES
            if (btn1.Text == letra && btn5.Text == letra && btn9.Text == letra)
            {
                return true;
            }

            if (btn3.Text == letra && btn5.Text == letra && btn7.Text == letra)
            {
                return true;
            } 

            return false;
        }

        private void Reiniciar()
        {
            foreach (Button boton in this.listaBotones)
            {
                boton.Text = "";
                boton.BackColor = Color.LightGray;
                boton.Enabled = true;
            }
        }

        private void ClickEnemigo()
        {
            Random numero = new Random();
            Button boton;
            do
            {
                boton = listaBotones[numero.Next(0, 8)];
            } while (boton.Enabled == false);
            boton.Text = "O";
            boton.BackColor = Color.Red;
            boton.Enabled = false;
        }

        private bool existeLugar()
        {
            bool retorno = false;
            foreach (Button boton in this.listaBotones)
            {
                if(boton.Enabled == true)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
    }
}
