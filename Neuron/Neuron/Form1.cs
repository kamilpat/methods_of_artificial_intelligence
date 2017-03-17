using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuron
{

    public partial class Form1 : Form
    {
        private Label[] labelkiInputs;
        private Label[] labelkiWeights;
        private Label[] labelkiActivationF;
        private Label[] labelkiOutput;
        private Label[] labelkiOczekiwanyWynik;
        private PictureBox[] ObrazkiNeuronow;
        private Layer layer;
        private double[,] weights;
        private double[,] data;
        private double[,] wynik ;
        private int numerGlownejpetli=0;
        private int NumerPrzykladu = 0;
        private int PoprawnezRzędu = 0;
        public Form1()
        {
            InitializeComponent();
        }
        class Network
        {
            private List<Layer> Layers;
        }


        class Layer
        {
            public List<NeuralCell> NeuralCells = new List<NeuralCell>(100);

            public Layer(int NeuralCellsQuantity, int inputQuantity)
            {
                for (int i = 0; i < NeuralCellsQuantity; i++)
                {
                    NeuralCells.Add(new NeuralCell(inputQuantity));
                }
            }

            public void setInput(double[] data)
            {
                int i = 0;
                foreach (var item in NeuralCells)
                {
                   
                {
                    for (int j = 0; j < data.Length; j++)
                    {
                        this.NeuralCells[i].setInputData(j, data[j]);
                    }
                }
                    i++;
                }
            }
            public void setInput(double[,] data,int numerDanych)
            {
                int i = 0;
                foreach (var item in NeuralCells)
                {
                 
                    
                        for (int j = 0; j < data.GetLength(1); j++)
                    {
                        this.NeuralCells[i].setInputData(j, data[numerDanych,j]);
                    }
                    i++;
                }
            }
            public void setWeights(double[,] weights)
            {
                for (int i = 0; i < weights.GetLength(0); i++)
                {

                    for (int j = 0; j < weights.GetLength(1); j++)
                    {
                        this.NeuralCells[i].setInputWeight(j, weights[i, j]);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (numerGlownejpetli == 0)
            {


                layer = new Layer(3, 3);
                data = new double[3, 3] { { 10, 2, -1 }, //te dane dobre
                { 10, 2, -1 }, ///// TE DANE TE SĄ ZŁE  jak i wartości należy zmienić
                { 10, 2, -1 } //// TE DANE TE SĄ ZŁE  jak i wartości należy zmienić dodać kolejne [numerPrzykładu,Poszcególne_Dane]
                
            };
                weights = new double[3, 3] { { 1, -2, 0 },
                                             { 0, -1, 2 },
                                             { 1,  3,-1 },
            };
                wynik = new double[3, 3]{ { 1, -1, -1 }, //te dane dobre
              { 1, -1, -1 },  ///// TE DANE TE SĄ ZŁE  jak i wartości należy zmienić
                { 1, -1, -1 }, /// TE DANE TE SĄ ZŁE  jak i wartości należy zmienić dodać kolejne [numerPrzykładu,Poszcególne_Dane]
            };


            }
        


            layer.setInput(data,NumerPrzykladu);
            layer.setWeights(weights);

            Display();

            Skoryguj(wynik,NumerPrzykladu);
           
    
            NumerPrzykladu++;// Pozwala na przejście do kolejnych przykładów i wyników 
    
          
            numerGlownejpetli++; //liczy przebiegi głównej pętli zapobiega kilkakrotnemu tworzeniu się obiektów
            if (NumerPrzykladu >= wynik.GetLength(0))
            {
                NumerPrzykladu = 0;
            }
            if (PoprawnezRzędu>=4)
            {
                label26.Text = "Akuku Nauczyłam Się !!! :) stworz 3 text bloxy i wczytaj tylko dane i mnie wypróbuj";
            }
            else
            {
                label26.Text = (PoprawnezRzędu).ToString();
            }
   
            label24.Text = numerGlownejpetli.ToString();
            label25.Text = (NumerPrzykladu+1).ToString();
         

        }

        private void Display()
        {
            if (numerGlownejpetli == 0)
            {
                labelkiInputs = new Label[100];
                labelkiWeights = new Label[100];
                labelkiOutput = new Label[100];
                labelkiActivationF = new Label[100];
                labelkiOczekiwanyWynik = new Label[100];
                ObrazkiNeuronow = new PictureBox[100];
            }
            int petlawag=0;
            int i=0;
            int dodatkowyodstep = 20;
            int odleglosc = 95;
            foreach (var item in layer.NeuralCells)
            {
                if (numerGlownejpetli == 0)
                { 
                ObrazkiNeuronow[i] = new PictureBox();
                    labelkiInputs[i] = new Label();
                    labelkiActivationF[i] = new Label();
                    labelkiOutput[i] = new Label();
                 labelkiOczekiwanyWynik[i]=new Label();
    }
              
                ObrazkiNeuronow[i] .Image = Properties.Resources.neuron ;
                ObrazkiNeuronow[i] .Location = new Point(400, 60 * i + odleglosc + 5);

                labelkiInputs[i].Location = new Point(230, 60 * i + odleglosc+20);
                 labelkiActivationF[i].Location = new Point(412, 60 * i + odleglosc + 20);
                labelkiOutput[i].Location = new Point(600, 60 * i + odleglosc + 20);
                labelkiOczekiwanyWynik[i].Location = new Point(700, 60 * i + odleglosc + 20);
                labelkiOczekiwanyWynik[i].AutoSize = true;

       

                labelkiInputs[i].AutoSize = true;
            
                labelkiActivationF[i].AutoSize = true;
                labelkiOutput[i].AutoSize = true;
                labelkiInputs[i].Text = layer.NeuralCells[i].getInputData(i).ToString();// Bierze DANE PO WEJŚCIACH PO KOLEI Z KOLEJNYCH NEURONÓW (DZIAŁA LECZ DO POPRAWIENIA)
                labelkiActivationF[i].Text = layer.NeuralCells[i].getMembranePotential().ToString();
                labelkiOutput[i].Text= layer.NeuralCells[i].getOutput().ToString();
                labelkiOczekiwanyWynik[i].Text = wynik[NumerPrzykladu, i].ToString();



                this.Controls.Add(labelkiInputs[i]);
              
                this.Controls.Add(labelkiActivationF[i]);
                this.Controls.Add(labelkiOutput[i]);
                this.Controls.Add(labelkiOczekiwanyWynik[i]);

                this.Controls.Add(ObrazkiNeuronow[i]);

    
                for (int j = 0; j < 3; j++)
                {
                    if (numerGlownejpetli == 0)
                    {
                        labelkiWeights[petlawag] = new Label();
                    }
                    
                    if (j == 2) 
                    {
                        labelkiWeights[petlawag].Location = new Point(325, (20 *petlawag)+ ( odleglosc));
                         odleglosc +=dodatkowyodstep;
                    }
                    else
                    {
                        labelkiWeights[petlawag].Location = new Point(325, 20 * petlawag + odleglosc);
                    }

                    labelkiWeights[petlawag].Text = layer.NeuralCells[i].getInputWeight(j).ToString();
                    labelkiWeights[petlawag].AutoSize = true;
        
                    this.Controls.Add(labelkiWeights[petlawag]);
                    petlawag++;
               
                }
                ++i;
   

            }

            //wagi 3
        

        }

        private void Skoryguj(double[,] wynik, int numerwyniku)
        {
            bool bezkorekty = true;
            for (int i = 0; i < 3; i++)
            {
                if (wynik[numerwyniku, i] != layer.NeuralCells[i].getOutput())
                {
                    for (int j = 0; j < 3; j++)
                    {
                        double nowawaga = layer.NeuralCells[i].getInputWeight(j) - layer.NeuralCells[i].getInputData(j);
                        layer.NeuralCells[i].setInputWeight(j, nowawaga);
                        weights[i, j] = nowawaga;

                    }
                    bezkorekty = false;
                    PoprawnezRzędu = 0;
                }
            }
            if (bezkorekty)
            {
                PoprawnezRzędu++;
            }
        }
    
        
        public class NeuralCell
        {
            /**
             * NeuralCell Ciało
             */
            private List<Double> Dendrites;
            private List<Double> Synapses;

            /**
             * Kontruktor klasy.
             */
            public NeuralCell()
            {
                Dendrites = new List<double>(100);
                Synapses = new List<double>(100);
            }
            public NeuralCell(int inputQuantity)
            {

                Dendrites = new List<double>(inputQuantity);
                Synapses = new List<double>(inputQuantity);
                this.addInput(inputQuantity);
            }

            /**
             * Metoda do przesłonięcia, aby uzyskać unikalne wyjście obliczeń. Domyślnie ma charakter liniowy.
             * @param membranePotential
             * @return	Dane po obróbce finalnych kalkulacji.
             */
            public double finalizeData(double membranePotential)
            {
                return membranePotential;
            }

            /**
             * 
             * @return Ilość istniejących dendrytów i synaps.
             */
            public int getInputSize()
            {
                return Dendrites.Capacity;
            }

            /**
             * Dodaje nowe pole wejściowe.
             */
            public void addInput()
            {
                Dendrites.Add(0.0);
                Synapses.Add(1.0);
            }

            /**
             * Dodaje okrośloną ilość pól wejściowych.
             * @param count
             */
            public void addInput(int count)
            {
                for (int i = 1; i <= count; i++)
                    this.addInput();
            }

            /**
             * Sprawdza wartość przechowywaną przez określony dendryt.
             * @param index
             * @return Wartość przechowywaną przez dany dendryt.
             */
            public double getInputData(int index)
            {
                return Dendrites[index];
            }

            /**
             * Ustawia wartość przechowywaną przez dendryt o określonym indeksie.
             * @param index
             * @param value
             */
            public void setInputData(int index, double value)
            {
                Dendrites[index] = value;
            }

            /**
             * Sprawdza wagę przechowywaną przez określoną synapsę.
             * @param index
             * @return Wagę przechowywaną przez daną synapsę.
             */
            public double getInputWeight(int index)
            {
                return Synapses[index];
            }

            /**
             * Ustawia wartość przechowywaną przez synapsę o określonym indeksie.
             * @param index
             * @param value
             */
            public void setInputWeight(int index, double weight)
            {

                Synapses[index] = weight;
            }

            /**
             * Przetwarza przechowywane dane w pojedynczym węźle neuronowym,którym jest dendryt
             * i przypisana do niego synapsa.
             * @param index
             * @return Wynik przetwarzania danych pojedynczego węzła.
             */
            public double processCellNode(int index)
            {
                return (Dendrites[index] * Synapses[index]);
            }

            /**
             * Oblicza potencjał membranowy pojedynczego neuronu.
             * @return Potencjał membranowy lub -1 w przypadku, gdy dane wejściowe nie istnieją.
             */
            public double getMembranePotential()
            {
                if (getInputSize() == 0)
                    return -1;

                double sum = 0;
                for (int i = 0; i < getInputSize(); i++)
                    sum += processCellNode(i);

                return sum;
            }

            /**
             * Oblicza wyjście pojedynczego neuronu.
             * @return Obliczone dane wyjściowe neuronu lub -1 w przypadku, gdy dane wejściowe nie istnieją.
             */
            public double ActivationFunction()
            {
                if (getInputSize() == 0)
                    return -1;

                return finalizeData(getMembranePotential());
            }
            public double getOutput()
            {
                return Math.Sign(ActivationFunction());
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Skoryguj(wynik,NumerPrzykladu);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] tmpdata = new double[1, 3];
            tmpdata[0, 0] = Convert.ToDouble(textBox1.Text);
            tmpdata[0, 1] = Convert.ToDouble(textBox2.Text);
            tmpdata[0, 2] = Convert.ToDouble(textBox3.Text);
            layer.setInput(tmpdata,0);
            layer.setWeights(weights);
            Display();
            label7.Text= layer.NeuralCells[0].getOutput().ToString();
            label8.Text = layer.NeuralCells[1].getOutput().ToString();
            label9.Text = layer.NeuralCells[2].getOutput().ToString();

        }
    }
}
