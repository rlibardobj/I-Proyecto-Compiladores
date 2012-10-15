/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 14/10/2012
 * Time: 05:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ASintactico;

namespace AContextual
{
	/// <summary>
	/// Description of nodoTabla.
	/// </summary>
	public class nodoTabla
	{
		public AST declaración;
		public string nombre;
		public int nivel;
		public nodoTabla(string nom, AST decl, int level)
		{
			nombre=nom;
			nivel=level;
			declaración=decl;
		}
	}
}
