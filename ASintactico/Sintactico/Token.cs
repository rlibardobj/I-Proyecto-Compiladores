/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 15/09/2012
 * Time: 06:54 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of Token.
	/// </summary>
	public class Token
	{
		public int sym, line, column;
		public string value;
		
		public Token(int tipo, int linea, int columna, string valor)
		{
			sym=tipo;
			line=linea;
			column=columna;
			value=valor;
		}
		public Token(int tipo, int linea, int columna)
		{
			sym=tipo;
			line=linea;
			column=columna;
		}
	}
}
