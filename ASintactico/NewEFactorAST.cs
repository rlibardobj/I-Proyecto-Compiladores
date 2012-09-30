/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of NewEFactorAST.
	/// </summary>
	public class NewEFactorAST:FactorAST
	{
		TerminalesAST ident;
		ExprAST expresion;
		public NewEFactorAST(ExprAST expr, TerminalesAST id)
		{
			expresion=expr;
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitNewEFactorAST(this,arg);
		}
	}
}
