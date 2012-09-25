/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 09:58 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of VarDeclAST.
	/// </summary>
	public abstract class VarDeclAST : AST
	{
		string value;
		public VarDeclAST(string valor)
		{
			value=valor;
		}
	}
}
