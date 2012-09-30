/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:49 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ExprFactorAST.
	/// </summary>
	public class ExprFactorAST:FactorAST
	{
		ExprAST expresion;
		public ExprFactorAST(ExprAST expr)
		{
			expresion=expr;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitExprFactorAST(this,arg);
		}
	}
}
