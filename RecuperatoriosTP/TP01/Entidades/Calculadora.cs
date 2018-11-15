using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Calculadora
  {
        /// <summary>
        /// Metodo que opera dos numeros de tipo Numero
        /// </summary>
        /// <param name="num1">primer numero a operar</param>
        /// <param name="num2">segundo numero a operar</param>
        /// <param name="operador">operador ingresado, por defecto +</param>
        /// <returns></returns>
    public double Operar(Numero num1, Numero num2, string operador)
    {
      switch (ValidarOperador(operador))
      {
        case "-":
          return num1 - num2;
        case "*":
          return num1 * num2;
        case "/":
          return num1 / num2;
        default:
          return num1 + num2;
      }
    }

        /// <summary>
        /// metodo que valida el operador y lo retorna, por defecto sera +
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns></returns>
    private static string ValidarOperador(string operador)
    {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            return operador;      
        }
  }
}
