/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 05:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of Errores.
	/// </summary>
	public class Errores
	{
		public string error;
		public int linea,columna;
		public Errores sigerror;
		public Errores(string e, int line, int column)
		{
			linea=line;
			columna=column;
			error=e;
			sigerror=null;
		}
	}
}
