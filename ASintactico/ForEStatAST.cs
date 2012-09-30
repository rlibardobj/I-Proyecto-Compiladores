/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:47 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ForEStatAST.
	/// </summary>
	public class ForEStatAST : StatementAST
	{
		ExprAST expresion,expresion1;
		StatementAST statement;
		public ForEStatAST(ExprAST expr, ExprAST expr1, StatementAST sta)
		{
			statement=sta;
			expresion=expr;
			expresion1=expr1;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitForEStatAST(this,arg);
		}
	}
}
