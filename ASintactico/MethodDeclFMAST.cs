/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclFMAST.
	/// </summary>
	public class MethodDeclFMAST : MethodDeclAST
	{
		FormParsAST parametros;
		DeclarationsAST declaraciones;
		public MethodDeclFMAST(FormParsAST par, DeclarationsAST decls)
		{
			parametros=par;
			declaraciones=decls;
		}
	}
}
