/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ReturnEStatAST.
	/// </summary>
	public class ReturnEStatAST : StatementAST
	{
		public ExprAST expresion;
		
		public ReturnEStatAST(ExprAST expr)
		{
			expresion=expr;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitReturnEStatAST(this,arg);
		}
	}
}
