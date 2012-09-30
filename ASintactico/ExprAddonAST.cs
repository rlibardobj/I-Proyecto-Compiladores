/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:55 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ExprAddonAST.
	/// </summary>
	public class ExprAddonAST:DesigAddonAST
	{
		ExprAST expresion;
		public ExprAddonAST(ExprAST expr)
		{
			expresion=expr;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitExprAddonAST(this,arg);
		}
	}
}
