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
        private int turno = 0;
        
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
            this.checkBox_PvsC.Checked = true;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            this.checkBox_PvsP.Enabled = false;
            this.checkBox_PvsC.Enabled = false;

            if (this.checkBox_PvsC.Checked) //PLAYER VS COMPUTER
            {
                if (boton.Text == "")
                {
                    boton.Text = "X";
                    boton.BackColor = Color.Aqua;
                    boton.Enabled = false;
                    if (this.chequear("X") == false) //SI NO SE GANO JUEGA MAQUINA
                    {
                        if (this.existeLugar())
                        {
                            this.clickEnemigo();
                            if (this.chequear("O") == false)
                            {
                                if (this.existeLugar() == false)
                                {
                                    MessageBox.Show("Empate");
                                    this.reiniciar();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Perdiste");
                                this.reiniciar();
                            }
                        }
                        else //SI NO HYA MAS LUGAR SE REINICIA
                        {
                            MessageBox.Show("Empate");
                            this.reiniciar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("GANASTE");
                        this.reiniciar();
                    }
                }
            }
            else //PLAYER VS PLAYER
            {
                if (boton.Text == "") 
                {
                    if (this.turno % 2 == 0) //JUGADOR 1
                    {
                        boton.Text = "X";
                        boton.BackColor = Color.Aqua;
                        boton.Enabled = false;
                        if (this.chequear("X"))
                        {
                            MessageBox.Show("Gano la X");
                            this.reiniciar();
                        }
                        else
                        {
                            if (this.existeLugar() == false)
                            {
                                MessageBox.Show("Empate");
                                this.reiniciar();
                            }
                        }
                    }
                    else //JUGADOR 2
                    {
                        boton.Text = "O";
                        boton.BackColor = Color.Red;
                        boton.Enabled = false;
                        if (this.chequear("O"))
                        {
                            MessageBox.Show("Gano la O");
                            this.reiniciar();
                        }
                        else
                        {
                            if (this.existeLugar() == false)
                            {
                                MessageBox.Show("Empate");
                                this.reiniciar();
                            }
                        }
                    }
                    this.turno++;
                }
            }
        }
        
        private bool chequear(string letra)
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

        private void reiniciar()
        {
            foreach (Button boton in this.listaBotones)
            {
                boton.Text = "";
                boton.BackColor = Color.LightGray;
                boton.Enabled = true;
            }
            this.checkBox_PvsP.Enabled = true;
            this.checkBox_PvsC.Enabled = true;
            this.turno = 0;
        }

        private void clickEnemigo()
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

        private void CheckBox_PvsP_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_PvsC.Checked = !this.checkBox_PvsP.Checked;
        }

        private void CheckBox_PvsC_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_PvsP.Checked = !this.checkBox_PvsC.Checked;
        }
    }
}
