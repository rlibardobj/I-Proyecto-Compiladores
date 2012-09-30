/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:33 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclFAST.
	/// </summary>
	public class MethodDeclFAST : DeclarationAST
	{
		FormParsAST parametros;
		TypeAST tipo;
		IDAST ident;
		public MethodDeclFAST(FormParsAST par,TypeAST tip, IDAST id)
		{
			parametros=par;
			ident=id;
			tipo=tip;
		}
	}
}
