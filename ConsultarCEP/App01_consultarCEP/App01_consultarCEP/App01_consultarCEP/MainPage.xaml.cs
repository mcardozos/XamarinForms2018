using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_consultarCEP.Servico.Modelo;
using App01_consultarCEP.Servico;

namespace App01_consultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            
            string cep = CEP.Text.Trim();

            if(isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("{0} {3} - {1} - {2} -", end.logradouro, end.localidade, end.uf, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço não foi encontrado para o CEP Informado.", "OK");
                    }
                    

                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro Crítico " , ex.Message, "OK");
                    
                }

                
            }
         
        }

        private Boolean isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido - O CEP deve conter 8 caracteres", "OK");
                valido = false;
            }

            int novocep = 0;

            if(!int.TryParse(cep, out novocep))
            {
                DisplayAlert("Erro", "CP Inválido - O CEP deve conter apenas números", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
