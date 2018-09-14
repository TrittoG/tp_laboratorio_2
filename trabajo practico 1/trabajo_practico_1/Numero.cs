using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajo_practico_1
{
    public class Numero
    {
        /// <summary>
        /// unico campo de la clase
        /// </summary>
        private Double numero;


        /// <summary>
        /// retorna el unico campo de la clase
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }
        
        /// <summary>
        /// valida si el numero a ingresar es valido y lo convierte a double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>retorna el numero a ser ingresado</returns>
        public static double ValidarNumero(string strNumero)
        {
            double num;

            if(double.TryParse(strNumero, out num))
            {
                return num;
            }

            return 0;
        }



        /// <summary>
        /// setea el numero previamente validado
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }



        /// <summary>
        /// constructor sin parametros lo inicializa con 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// constructor con un parametro double
        /// </summary>
        /// <param name="numero">inicializa el campo con el numero ingresado</param>
        public Numero(double numero)
        {
            this.numero = numero;            
        }

        /// <summary>
        /// constructor con parametro string, antes de setearlo lo valida y convierte
        /// </summary>
        /// <param name="strNumero">inicializa el campo con el valor ingresado previamente convertido a double</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;

        }





        /// <summary>
        /// sobrecarga del operador "+"
        /// </summary>
        /// <param name="n1">primer elemento a sumar</param>
        /// <param name="n2">segundo elemento a sumar</param>
        /// <returns>retorna el valor de los elementos sumados, en caso de que alguno sea nulo retorna 0</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            if(!(n1 is null || n2 is null))
                return n1.getNumero() + n2.getNumero();
            return 0;//no se que retorna si alguno de los dos es nulo
        }

        /// <summary>
        /// sobrecarga del operador -
        /// </summary>
        /// <param name="n1">primer elemento a restar</param>
        /// <param name="n2">segundo elemento a restar</param>
        /// <returns>retorna la resta de los elementos, en caso de que alguno sea nulo retorna 0</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            if (!(n1 is null || n2 is null))
                return n1.getNumero() - n2.getNumero();
            return 0;
        }

        /// <summary>
        /// sobrecarga del operador *
        /// </summary>
        /// <param name="n1">primero elemento a multiplicar</param>
        /// <param name="n2">segundo elemento a multiplicar</param>
        /// <returns>retorna la multiplicacion de los elementos, si alguno es nulo retorna 0</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            if (!(n1 is null || n2 is null))
                return n1.getNumero() * n2.getNumero();
            return 0;
        }

        /// <summary>
        /// sobrecarga del operador /
        /// </summary>
        /// <param name="n1">primer nuero a dividir</param>
        /// <param name="n2">segundo numero a dividir</param>
        /// <returns>retorna la multiplicacion de los elementos, si alguno es nulo o el segundo parametro es 0 retornara 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (!(n1 is null || n2 is null))
            {
                if (n2.getNumero() == 0)
                {
                    return 0;
                }
                return n1.getNumero() / n2.getNumero();
            }
            return 0;
                
        }

        /// <summary>
        /// convierte un valor ingresado binario a decimal double
        /// </summary>
        /// <param name="binario">numero vinario a ser convertido</param>
        /// <returns>valor decimal de la conversion</returns>
        public static string BinarioDecimal(string binario)
        {
            double retorno = 0;
            int i, j = binario.Length;

            if(binario is null || binario == "")
            {
                return "E";
            }
            for (i = 0; i < binario.Length; i++)
            {
                j--;
                if (binario[i] == '1')
                {
                    retorno = retorno + Math.Pow(2, j);
                }

            }
            return string.Format("{0}",retorno);
        }



        /// <summary>
        /// convierte un valor double a binario
        /// </summary>
        /// <param name="doble">numero a convertir a binario</param>
        /// <returns>retorna el numero binario en string</returns>
        public static string DecimalBinario(double doble)
        {
            string binario = "";

            if(doble < 0)
            {
                return null;
            }
            while (doble > 0)
            {


                if (doble % 2 == 1)
                {
                    binario = '1' + binario;
                }
                else
                {
                    binario = '0' + binario;
                }

                doble = (int)doble / 2;

            }
            return binario;
        }



        /// <summary>
        /// convierte un valor string a binario
        /// </summary>
        /// <param name="numero">el numero a convertir de tipo string</param>
        /// <returns>valor en binario, en caso que no se pueda parsear el string retorna E(error)</returns>
        public static string DecimalBinario(string numero)
        {
            double dblNumero;

            if(double.TryParse(numero, out dblNumero))
            {
                return DecimalBinario(dblNumero);
            }
            return "E";
        }

    }
}
