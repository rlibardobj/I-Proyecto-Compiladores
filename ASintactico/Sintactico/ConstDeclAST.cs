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
		public Token value;
		public TypeAST tipo;
		public string adornotipo;
		
		public ConstDeclAST(TypeAST tip, Token valor)
		{
			value=valor;
			tipo=tip;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitConstDeclAST(this,arg);
		}
	}
}
