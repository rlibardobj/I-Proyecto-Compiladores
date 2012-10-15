/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 14/10/2012
 * Time: 05:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ASintactico
{
	/// <summary>
	/// Description of tablaSimbolos.
	/// </summary>
	public class tablaSimbolos
	{
		LinkedList<nodotabla> tabla;
		int nivel;
		public tablaSimbolos()
		{
			tabla=new LinkedList<nodotabla>;
			nivel=0;
		}
	}
}
