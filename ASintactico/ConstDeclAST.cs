/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 09:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ConstDeclAST.
	/// </summary>
	public class ConstDeclAST : DeclarationAST
	{
		string value;
		TypeAST tipo;
		public ConstDeclAST(TypeAST tip, string valor)
		{
			value=valor;
			tipo=tip;
		}
	}
}
