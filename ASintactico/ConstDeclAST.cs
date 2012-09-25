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
	public class ConstDeclAST : AST
	{
		string value;
		public ConstDeclAST(string valor)
		{
			value=valor;
		}
	}
}
