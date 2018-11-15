using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Numero
  {
    /// <summary>
    /// fields
    /// </summary>
    private double numero;

    /// <summary>
    /// propiedad de solo escritura que valida el numero y lo setea en el campo numero
    /// </summary>
    public string SetNumero
    {
      set
      {
        this.numero = ValidarNumero(value);
      }
    }

    /// <summary>
    /// constructor por defecto, seteando a numero con 0
    /// </summary>
    public Numero()
    {
      this.numero = 0;
    }

    /// <summary>
    /// constructor que recibe un double y lo setea en el numero
    /// </summary>
    /// <param name="numero"></param>
    public Numero(double numero)
    {
      this.numero = numero;
    }

    /// <summary>
    /// constructor que recibe un string, lo pasa a double y lo setea en numero
    /// </summary>
    /// <param name="strNumero"></param>
    public Numero(string strNumero)
    {
      this.SetNumero = strNumero;
    }
    
    /// <summary>
    /// metodo privado que valida el numero ingresado como string y lo retorna como double
    /// </summary>
    /// <param name="strNumero">numero string a ser pasado a double</param>
    /// <returns></returns>
    private double ValidarNumero(string strNumero)
    {

            if (double.TryParse(strNumero, out double auxiliar))
                return auxiliar;
            return 0;
    }


    /// <summary>
    /// sobrecarga del operador + para sumar dos objetos de tipo Numero y retorna el resultado
    /// </summary>
    /// <param name="n1">primer numero a sumar</param>
    /// <param name="n2">segundo numero a sumar</param>
    /// <returns></returns>
    public static double operator +(Numero n1, Numero n2)
    {
            if (!(n1 is null) || !(n2 is null))
                return n1.numero + n2.numero;
            return 0;
    }

    /// <summary>
    /// sobrecarga del operador - para restar dos objetos de tipo Numero y retorna el resultado
    /// </summary>
    /// <param name="n1">primer numero a restar</param>
    /// <param name="n2">segundo numero a restar</param>
    /// <returns></returns>
    public static double operator -(Numero n1, Numero n2)
    {
            if (!(n1 is null) || !(n2 is null))
                return n1.numero - n2.numero;
            return 0;
    }

    /// <summary>
    /// sobrecarga del operador * para multiplicar dos objetos de tipo Numero y retorna el resultado
    /// </summary>
    /// <param name="n1">primer numero a multiplicar</param>
    /// <param name="n2">segundo numero a multiplicar</param>
    /// <returns></returns>
    public static double operator *(Numero n1, Numero n2)
    {
            if (!(n1 is null) || !(n2 is null))
                return n1.numero * n2.numero;
            return 0;
    }

    /// <summary>
    /// sobrecarga del operador / para dividir dos objetos de tipo Numero y retorna el resultado
    /// </summary>
    /// <param name="n1">dividendo</param>
    /// <param name="n2">divisor</param>
    /// <returns></returns>
    public static double operator /(Numero n1, Numero n2)
    {
            if (!(n1 is null) || !(n2 is null))
                if(n2.numero != 0)
                    return n1.numero / n2.numero;
            return 0;
    }


    /// <summary>
    /// metodo publico que convierte un binario a decimal, retornandolo. Si el numero ingresado no
    /// es Binario retorna 0
    /// </summary>
    /// <param name="binario">numero en binario</param>
    /// <returns></returns>
    public static string BinarioDecimal(string binario)
    {
            char[] arrayChars = binario.ToCharArray();
            Array.Reverse(arrayChars);
            double decim = 0;
            int tamanio = binario.Length;
            int i;
           
            for (i = 0; i < tamanio; i++)
            {
                if (arrayChars[i] != '0' && arrayChars[i] != '1')
                {
                    return "Valor Invalido";
                }
                   
                if (arrayChars[i] == '1')
                {
                    decim = decim + Math.Pow(2, i);
                }
            }
            return string.Format("{0}", decim);

    }

    /// <summary>
    /// metodo publico estatico que convierte un decimal a binario retornandolo
    /// </summary>
    /// <param name="numero">numero decimal de tipo double</param>
    /// <returns></returns>
    public static string DecimalBinario(double numero)
    {
            string bin = "";

            if(numero >=0)
            {
                while(numero > 0)
                {
                    if(numero % 2 == 0)
                    {
                        bin = "0" + bin;
                    }
                    else
                    {
                        bin = "1" + bin;
                    }
                    numero = (int)numero / 2;
                }
            }
            else
            {
                return "0";
            }
            return bin;
    }



    /// <summary>
    /// metodo publico estatico que convierte un decimal a binario, retornandolo
    /// </summary>
    /// <param name="numero">numero decimal de tipo string</param>
    /// <returns></returns>
    public static string DecimalBinario(string numero)
    {
            if(double.TryParse(numero,out double nDouble))
            {
                return DecimalBinario(nDouble);
            }
            return "0";
    }

    
  }
}
